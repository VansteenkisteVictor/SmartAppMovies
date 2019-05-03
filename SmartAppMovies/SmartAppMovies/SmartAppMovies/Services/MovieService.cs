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
        public MovieService(ISearchRepo searchRepo,IDetailRepo detailRepo,IReviewRepo reviewRepo,IAddReviewRepo addReviewRepo)
        {
            _searchRepo = searchRepo;
            _detailRepo = detailRepo;
            _reviewRepo = reviewRepo;
            _addReviewRepo = addReviewRepo;
            
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

        public async Task PostReview(Review review)
        {
            await _addReviewRepo.AddReview(review);
        }
    }
}
