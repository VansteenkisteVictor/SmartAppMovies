using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IAddLogin
    {
        Task AddLoginAsync(Login login);
    }
}