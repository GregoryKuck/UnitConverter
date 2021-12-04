namespace UnitConverters
{
    public interface IConversionManager
    {
        decimal Convert(string conversionType, decimal value);
        IList<string> GetAllUnitsOfMeasurement();
    }
}