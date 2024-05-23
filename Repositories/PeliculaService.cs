using backend.Data;
using backend.DTOs;
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

        private IMongoCollection<Genero> _generoCollection;

        public PeliculaService(){
            _collection = _repository.db.GetCollection<Pelicula>("Peliculas");
            _generoCollection = _repository.db.GetCollection<Genero>("Generos");
        }

        public async Task<List<PeliculaResponse>> GetPeliculas()
        {
            var peliculas = await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            var peliculasResponse = new List<PeliculaResponse>();

            foreach (var pelicula in peliculas)
            {
                var generos = new List<GeneroDto>();

                foreach (var generoId in pelicula.GeneroIds)
                {
                    var genero = await _generoCollection.Find(g => g.Id == generoId).FirstOrDefaultAsync();
                    if (genero != null)
                    {
                        generos.Add(new GeneroDto
                        {
                            Id = genero.Id.ToString(),
                            Nombre = genero.nombre,
                        });
                    }
                }

                peliculasResponse.Add(new PeliculaResponse
                {
                    Id = pelicula.Id,
                    Titulo = pelicula.titulo,
                    VideoUrl = pelicula.VideoUrl,
                    Generos = generos
                });
            }

            return peliculasResponse;
        }

        public async Task insertPeliculas(Pelicula pelicula)
        {
            await _collection.InsertOneAsync(pelicula);
        }
    }
}