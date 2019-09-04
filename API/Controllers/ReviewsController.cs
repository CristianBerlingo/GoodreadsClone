using System.Collections.Generic;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IBaseService<Review> _reviewService;

        public ReviewsController(IBaseService<Review> reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/reviews
        [HttpGet]
        [EnableQuery()]
        public List<Review> Get()
        {
            return _reviewService.Get();
        }

        // GET api/reviews/5
        [HttpGet("{id}")]
        public Review Get(int id)
        {
            return _reviewService.GetById(id);
        }

        // POST api/reviews
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            if(ModelState.IsValid)
            {
                _reviewService.Create(review);
            }
        }

        // PUT api/reviews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review)
        {

            if(ModelState.IsValid)
            {
                review.Id = id;
                _reviewService.Update(review);
            }
        }

        // DELETE api/reviews/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reviewService.Delete(id);
        }
    }
}