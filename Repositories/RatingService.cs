using backend.Data;
using backend.Models;
using backend.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Repositories
{
    public class RatingService : IRatingService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Rating> _collection;
        public RatingService(){
            _collection = _repository.db.GetCollection<Rating>("Ratings");
        }
        public async Task<List<Rating>> GetAllRatings()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertRating(Rating rating)
        {
            await _collection.InsertOneAsync(rating);
        }

        public async Task UpdateRating(Rating rating)
        {
            var filtro = Builders<Rating>.Filter.Eq(s => s.id,rating.id);
            await _collection.ReplaceOneAsync(filtro,rating);
        }
    }
}