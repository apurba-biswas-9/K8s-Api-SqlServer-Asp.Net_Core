using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApiK8s.Models;

namespace testApiK8s.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TestContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

       

        [HttpPost]
        public IActionResult Save()
        {

            _dbContext.TestTables.Add(new TestTable {  Name =  "Apurba"   }); 
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
           
           return Ok(_dbContext.TestTables.Select(s => s).ToList());
        }
    }
}
