using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IPeliculaService
    {
        Task<List<PeliculaResponse>> GetPeliculas();
        Task insertPeliculas(Pelicula pelicula);
    }
}