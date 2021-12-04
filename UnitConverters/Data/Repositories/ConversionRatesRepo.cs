namespace UnitConverters.Data.Repositories
{
    public class ConversionRatesRepo : IConversionRatesRepo
    {
        private readonly UnitConversionContext _dbContext;

        public ConversionRatesRepo(UnitConversionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dictionary<string, string> GetConversionFormulae()
        {
            return _dbContext.UnitConversionFormulae.ToDictionary(o => o.ConversionKey, o => o.ConversionFormula);
        }
    }
}
