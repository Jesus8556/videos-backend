using backend.Data;
using backend.Models;
using backend.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Repositories
{
    public class PeliculaService : IPeliculaService
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Pelicula> _collection;

        public PeliculaService(){
            _collection = _repository.db.GetCollection<Pelicula>("Peliculas");
        }

        public async Task<List<Pelicula>> GetPeliculas()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
    
        }

        public async Task insertPeliculas(Pelicula pelicula)
        {
            await _collection.InsertOneAsync(pelicula);
        }
    }
}