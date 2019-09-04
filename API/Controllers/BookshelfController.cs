using System.Collections.Generic;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookshelfController : ControllerBase
    {
        private readonly IBaseService<Bookshelf> _bookshelfService;

        public BookshelfController(IBaseService<Bookshelf> bookshelfService)
        {
            _bookshelfService = bookshelfService;
        }

        // GET api/bookshelf
        [HttpGet]
        public List<Bookshelf> Get()
        {
            return _bookshelfService.Get();
        }

        // GET api/bookshelf/5
        [HttpGet("{id}")]
        public Bookshelf Get(int id)
        {
            return _bookshelfService.GetById(id);
        }

        // POST api/bookshelf
        [HttpPost]
        public void Post([FromBody] Bookshelf bookshelf)
        {
            if(ModelState.IsValid)
            {
                _bookshelfService.Create(bookshelf);
            }
        }

        // PUT api/bookshelf/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bookshelf bookshelf)
        {

            if(ModelState.IsValid)
            {
                bookshelf.Id = id;
                _bookshelfService.Update(bookshelf);
            }
        }
    }
}