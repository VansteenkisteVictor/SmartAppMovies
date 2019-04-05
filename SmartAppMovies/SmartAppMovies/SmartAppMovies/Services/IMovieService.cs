using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Services
{
    public interface IMovieService
    {
        Task<List<MovieDetail>> GetMovieDetail(string q);
        Task<MovieSearch> GetMovieSearch(string q);
    }
}