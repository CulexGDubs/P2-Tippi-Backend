using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using TrippiBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IBL _bl;
        public RatingController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<RatingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Rating> foundRatings = await _bl.GetAllRatingsAsync();
            if (foundRatings.Count > 0)
            {
                return Ok(foundRatings);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Rating foundRating = await _bl.GetRatingAsync(id);
            if (foundRating != null)
            {
                return Ok(foundRating);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<RatingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rating rating)
        {
            Rating addedRating = await _bl.CreateRatingAsync(rating);
            return Created("api/[controller]", addedRating);
        }

        // PUT api/<RatingController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteRatingAsync(id);
        }
    }
}
