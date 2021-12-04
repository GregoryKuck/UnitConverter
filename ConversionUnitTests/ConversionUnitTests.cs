using ConversionUnitTests.Mocks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverters;
using UnitConverters.Options;

namespace ConversionUnitTests
{
    [TestClass]
    public class ConversionUnitTests
    {
        private static IConversionManager _conversionMananger;

       [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _conversionMananger = new DatatableConversionManager(new MockRepo(), Options.Create(new ConverterOptions()), new NullLogger<DatatableConversionManager>());

        }

        [TestMethod]
        public void TestFahrenheitToCelsius()
        {
            //"FahrenheitToCelsius", "(x - 32) / 1.8"
            var converted = _conversionMananger.Convert("FahrenheitToCelsius", 50M);
          
            decimal expected = 10.00M;

            Assert.AreEqual(expected, converted);
        }

        [TestMethod]
        public void TestCelsiusToFahrenheit()
        {
            //"CelsiusToFahrenheit", "(x * 1.8) + 32"
            var converted = _conversionMananger.Convert("CelsiusToFahrenheit", 10M);

            decimal expected = 50.00M;

            Assert.AreEqual(expected, converted);
        }

        [TestMethod]
        public void TestMillimetreToInch()
        {
            //"MillimetreToInch", "x / 25.4"
            var converted = _conversionMananger.Convert("MillimetreToInch", 254M);

            decimal expected = 10.00M;

            Assert.AreEqual(expected, converted);
        }
    }
}