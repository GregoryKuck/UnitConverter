using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverters.Data.Models
{
    public class UnitConversionFormulae
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ConversionKey { get; set; }
        public string ConversionFormula { get; set; }
    }
}
