using UnitConverters.Data.Models;

namespace UnitConverters.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(UnitConversionContext context)
        {
            context.Database.EnsureCreated();

            if (context.UnitConversionFormulae.Any())
            {
                return;   // DB has been seeded
            }

            var formulae = new UnitConversionFormulae[]
            {
                new UnitConversionFormulae { ConversionKey = "FahrenheitToCelsius", ConversionFormula = "(x - 32) / 1.8" },
                new UnitConversionFormulae { ConversionKey = "CelsiusToFahrenheit", ConversionFormula = "(x * 1.8) + 32" },

                new UnitConversionFormulae { ConversionKey = "MillimetreToMetre", ConversionFormula = "x / 1000" },
                new UnitConversionFormulae { ConversionKey = "MetreToMillimetre", ConversionFormula = "x * 1000" },

                new UnitConversionFormulae { ConversionKey = "MillimetreToInch", ConversionFormula = "x / 25.4" },
                new UnitConversionFormulae { ConversionKey = "InchToMillimetre", ConversionFormula = "x * 25.4" },

                new UnitConversionFormulae { ConversionKey = "MetreToInch", ConversionFormula = "x * 39.37" },
                new UnitConversionFormulae { ConversionKey = "InchToMetre", ConversionFormula = "x / 39.37" },

                new UnitConversionFormulae { ConversionKey = "LitreToFluidOunce", ConversionFormula = "x * 33.814" },
                new UnitConversionFormulae { ConversionKey = "FluidOunceToLitre", ConversionFormula = "x / 33.814" },
            };

            foreach (var formula in formulae)
            {
                context.UnitConversionFormulae.Add(formula);
            }
            context.SaveChanges();
        }
    }
}
