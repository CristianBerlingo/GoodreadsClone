using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Book1", "Book2" };
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return string.Format("Book {0}", id);
        }

        // POST api/books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
