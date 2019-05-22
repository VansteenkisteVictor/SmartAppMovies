using SmartAppMovies.Models;
using SmartAppMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly ISearchRepo _searchRepo;
        private readonly IDetailRepo _detailRepo;
        private readonly IReviewRepo _reviewRepo;
        private readonly IAddReviewRepo _addReviewRepo;
        private readonly IAddLogin _addLogin;
        private readonly IGetLogin _getLogin;
        private readonly IGetUserReview _getUserReview;
        private readonly IDeleteReview _deleteReview;
        private readonly IUpdateReview _updateReview;
        public MovieService(ISearchRepo searchRepo,IDetailRepo detailRepo,IReviewRepo reviewRepo,IAddReviewRepo addReviewRepo, IGetLogin getLogin, IAddLogin addLogin, IGetUserReview getUserReview,IDeleteReview deleteReview, IUpdateReview updateReview)
        {
            _searchRepo = searchRepo;
            _detailRepo = detailRepo;
            _reviewRepo = reviewRepo;
            _addReviewRepo = addReviewRepo;
            _addLogin = addLogin;
            _getLogin = getLogin;
            _getUserReview = getUserReview;
            _deleteReview = deleteReview;
            _updateReview = updateReview;
            
        }
        public async Task<MovieSearch> GetMovieSearch(string q)
        {
            return await _searchRepo.GetMovieSearch(q);
        }
        public async Task<MovieDetail> GetMovieDetail(string q)
        {
            return await _detailRepo.GetMovieDetail(q);
        }
        public async Task<List<Review>> GetReview(string q)
        {
            return await _reviewRepo.GetMovieReview(q);
        }

        public async Task PostReview(PostReview review)
        {
            await _addReviewRepo.AddReview(review);
        }

        public async Task UpdateReview(PostReview review)
        {
            await _updateReview.Update(review);
        }

        public async Task AddLogin(Login login)
        {
            await _addLogin.AddLoginAsync(login);
        }

        public async Task DeleteReview(string q)
        {
            await _deleteReview.Delete(q);
        }

        public async Task<Login> GetLogin(string q)
        {
           return await _getLogin.GetLoginAsync(q);
        }

        public async Task<List<Review>> GetUserReview(string q)
        {
            return await _getUserReview.GetUserReviewAsync(q);
        }
    }
}
