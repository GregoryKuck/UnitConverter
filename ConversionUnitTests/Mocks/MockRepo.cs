using System.Collections.Generic;
using UnitConverters.Data.Repositories;

namespace ConversionUnitTests.Mocks
{
    internal class MockRepo : IConversionRatesRepo
    {
        public Dictionary<string, string> GetConversionFormulae()
        {
            return new Dictionary<string, string> 
            {
                //Add other formula that need testing to this collection
                { "FahrenheitToCelsius", "(x - 32) / 1.8" },
                { "CelsiusToFahrenheit", "(x * 1.8) + 32" },
                { "MillimetreToInch", "x / 25.4" }
            };
        }
    }
}
