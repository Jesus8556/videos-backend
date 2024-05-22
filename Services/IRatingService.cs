using backend.Models;

namespace backend.Services
{
    public interface IRatingService
    {

        Task InsertRating(Rating rating);
        Task UpdateRating(Rating rating);
        Task <List<Rating>> GetAllRatings();     
    }
}