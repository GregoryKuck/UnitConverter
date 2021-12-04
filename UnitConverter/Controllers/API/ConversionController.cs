using Microsoft.AspNetCore.Mvc;
using UnitConverter.Models.RequestModels;
using UnitConverters;

namespace UnitConverter.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        IConversionManager _manager;

        public ConversionController(IConversionManager manager)
        {
            _manager = manager;
        } 

        [HttpPost]
        public ActionResult<decimal> Convert(ConversionRequestModel request)
        {
            try
            {
                return Ok(_manager.Convert(request.Conversion, request.ValueToConvert));
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IList<string>> GetAllUnitsOfMeasurement()
        {
            return Ok(_manager.GetAllUnitsOfMeasurement());
        }
    }
}
