using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IDetailRepo
    {
        Task<List<MovieDetail>> GetMovieDetail(string q);
    }
}