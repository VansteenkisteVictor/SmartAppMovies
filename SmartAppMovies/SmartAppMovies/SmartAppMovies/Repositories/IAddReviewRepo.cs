using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IAddReviewRepo
    {
        Task AddReview(PostReview review);
    }
}