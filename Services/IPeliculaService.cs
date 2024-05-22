using backend.Models;

namespace backend.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetPeliculas();
        Task insertPeliculas(Pelicula pelicula);
    }
}