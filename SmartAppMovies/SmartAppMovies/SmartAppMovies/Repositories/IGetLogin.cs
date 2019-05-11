using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Repositories
{
    public interface IGetLogin
    {
        Task<Login> GetLoginAsync(string q);
    }
}