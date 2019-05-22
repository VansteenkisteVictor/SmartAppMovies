using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IUpdateReview
    {
        Task Update(PostReview review);
    }
}