using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface ISearchRepo
    {
        Task<MovieSearch> GetMovieSearch(string q);
    }
}