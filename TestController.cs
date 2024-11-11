// Controllers/TestsController.cs
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private static List<TestModel> tests = new List<TestModel>();

        // GET: api/tests
        [HttpGet]
        public ActionResult<List<TestModel>> GetTests()
        {
            return Ok(tests);
        }

        // GET: api/tests/{id}
        [HttpGet("{id}")]
        public ActionResult<TestModel> GetTest(string id)
        {
            var test = tests.FirstOrDefault(t => t.Id == id);
            if (test == null) return NotFound("Test not found");
            return Ok(test);
        }

        // POST: api/tests
        [HttpPost]
        public ActionResult<TestModel> CreateTest([FromBody] TestModel test)
        {
            test.Id = System.Guid.NewGuid().ToString();
            tests.Add(test);
            return CreatedAtAction(nameof(GetTest), new { id = test.Id }, test);
        }

        // POST: api/tests/{id}/check
        [HttpPost("{id}/check")]
        public ActionResult CheckTest(string id, [FromBody] List<int> userAnswers)
        {
            var test = tests.FirstOrDefault(t => t.Id == id);
            if (test == null) return NotFound("Test not found");

            int score = 0;
            for (int i = 0; i < test.Questions.Count; i++)
            {
                if (userAnswers[i] == test.Questions[i].CorrectAnswer) score++;
            }

            return Ok(new { score, total = test.Questions.Count });
        }
    }
}
