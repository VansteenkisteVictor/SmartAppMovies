using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IDetailRepo
    {
        Task<MovieDetail> GetMovieDetail(string q);
    }
}