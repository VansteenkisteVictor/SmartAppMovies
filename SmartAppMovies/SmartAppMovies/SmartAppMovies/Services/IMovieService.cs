using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAppMovies.Models;

namespace SmartAppMovies.Services
{
    public interface IMovieService
    {
        Task AddLogin(Login login);
        Task<Login> GetLogin(string q);
        Task<MovieDetail> GetMovieDetail(string q);
        Task<MovieSearch> GetMovieSearch(string q);
        Task<List<Review>> GetReview(string q);
        Task<List<Review>> GetUserReview(string q);
        Task PostReview(Review review);
    }
}