using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repro;

namespace Web.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly TestContext _context;

        public TestController(TestContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult AddTestEntity()
        {
            var result = _context.TestEntities.Add(new TestEntity
            {
                SmallDate = DateTime.UtcNow
            });
            _context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(result.Entity));
        }
    }
}