using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GoodreadsCloneAPI.Services;
using GoodreadsCloneAPI.Models;
using Microsoft.AspNet.OData;
using GoodreadsCloneAPI.Extensions;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseService<Book> _bookService;

        public BooksController(IBaseService<Book> bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        [EnableQuery()]
        public List<Book> Get()
        {
            return _bookService.Get();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookService.GetById(id);
        }

        // POST api/books
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            if(ModelState.IsValid)
            {
                _bookService.Create(book);
            }
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {

            if(ModelState.IsValid)
            {
                book.Id = id;
                _bookService.Update(book);
            }
        }

        // DELETE api/books/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // Delete books is unavailable, one time a book is added this can't be deleted
    }
}
