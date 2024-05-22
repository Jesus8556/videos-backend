using System.Data.Common;
using backend.Models;
using backend.Repositories;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase

    {
        private IRatingService _db = new RatingService();
        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _db.GetAllRatings();
            return Ok(ratings);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] Rating rating)
        {
            await _db.InsertRating(rating);
            return Created("Created",true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(string id, [FromBody] Rating rating)
        {
            rating.id = new MongoDB.Bson.ObjectId(id);

            await _db.UpdateRating(rating);
            return Created("Created",true);
        } 
    }
}