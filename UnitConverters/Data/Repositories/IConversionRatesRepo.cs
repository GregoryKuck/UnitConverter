
namespace UnitConverters.Data.Repositories
{
    public interface IConversionRatesRepo
    {
        Dictionary<string, string> GetConversionFormulae();
    }
}