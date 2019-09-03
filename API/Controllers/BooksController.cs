using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GoodreadsCloneAPI.Services;
using GoodreadsCloneAPI.Models;
using Microsoft.AspNet.OData;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        [EnableQuery()]
        public List<Book> Get()
        {
            return _bookService.GetBooks();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookService.GetById(id);
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
