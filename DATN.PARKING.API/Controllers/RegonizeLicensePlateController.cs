using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.InterfaceMethod;
using Microsoft.AspNetCore.Mvc;

namespace DATN.PARKING.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegonizeLicensePlateController : ControllerBase
    {

        private readonly IServiceParking _service;
       
       

        [HttpPost("send-data")]
        public async Task<ActionResult> RecivedData(string data)
        {
            var result = data;
            return Ok(result);
        }

    }
}
