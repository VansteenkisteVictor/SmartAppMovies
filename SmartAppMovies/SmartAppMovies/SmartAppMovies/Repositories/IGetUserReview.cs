using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IGetUserReview
    {
        Task<List<Review>> GetUserReviewAsync(string q);
    }
}