using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Globalization;
using UnitConverters.Data.Repositories;
using UnitConverters.Options;

namespace UnitConverters
{
    public class DatatableConversionManager : IConversionManager
    {
        private readonly IConversionRatesRepo _repo;
        private readonly ILogger<DatatableConversionManager> _logger;
        private readonly ConverterOptions _options;
        private static Dictionary<string, string>? _conversionFormulae;

        public DatatableConversionManager(IConversionRatesRepo repo, IOptions<ConverterOptions> options, ILogger<DatatableConversionManager> logger)
        {
            _repo = repo;
            _options = options.Value;
            _logger = logger;

            //NOTE: This will auto-resolve once database connection is restored but could be handled in several different fashions 
            _conversionFormulae = _conversionFormulae ?? GetConversionFormulae();
        }

        public IList<string> GetAllUnitsOfMeasurement()
        {
            return _options.Units;
        }

        public decimal Convert(string conversionType, decimal value)
        {
            if (_conversionFormulae != null && _conversionFormulae.ContainsKey(conversionType))
            {
                var baseFormula = _conversionFormulae[conversionType];

                if (!string.IsNullOrWhiteSpace(baseFormula))
                    return Math.Round(Evaluate(baseFormula.Replace("x", value.ToString(CultureInfo.InvariantCulture))), _options.DecimalRoundingPrecision);
            }

            throw new ArgumentException($"No base formula found for: {conversionType}");
        }

        //NOTE: There are many ways to approach this typically involving some form of operator overloading or custom operator creation,
        //to recreate the formula. This could more easily be solved using constants instead of storing conversion rates in the database.
        //This is a far easier and less error-prone apporach given the assignment requirements.
        private decimal Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("conversionExpression", string.Empty.GetType(), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            try
            {
                return decimal.Parse((string)row["conversionExpression"]);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, ex.Message);
                throw new ArgumentException($"Invalid formula: {(string)row["conversionExpression"]}");
            }
        }

        private Dictionary<string, string>? GetConversionFormulae()
        {
            try
            {
                return _repo.GetConversionFormulae();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            //NOTE: Returning null will allow it to self-heal once DB functionality is restored
            return null;
        }
    }
}
