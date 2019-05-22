using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public interface IDeleteReview
    {
        Task Delete(string q);
    }
}