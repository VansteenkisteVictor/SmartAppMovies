using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IReviewRepo
    {
        Task<List<Review>> GetMovieReview(string q);
    }
}