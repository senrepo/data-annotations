
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers
{

    //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.1
    
    [Route("api/[controller]")]
    [ApiController]
    public class TestValidationController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{param1}/{param2}")]
        public ActionResult<string> Get([Required] string param1, [StringLength(10)] string param2)
        {
            return $"value param1: {param1}, param2: {param2} ";
        }

        [HttpGet("{age}")]
        public ActionResult<string> GetAge( [Required, MinAge(10)] int age)
        {
            return $"age : {age}";
        }

    }
}