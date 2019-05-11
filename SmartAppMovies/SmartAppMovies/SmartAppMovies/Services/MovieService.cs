﻿using SmartAppMovies.Models;
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
        public MovieService(ISearchRepo searchRepo,IDetailRepo detailRepo,IReviewRepo reviewRepo,IAddReviewRepo addReviewRepo, IGetLogin getLogin, IAddLogin addLogin, IGetUserReview getUserReview)
        {
            _searchRepo = searchRepo;
            _detailRepo = detailRepo;
            _reviewRepo = reviewRepo;
            _addReviewRepo = addReviewRepo;
            _addLogin = addLogin;
            _getLogin = getLogin;
            _getUserReview = getUserReview;
            
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

        public async Task AddLogin(Login login)
        {
            await _addLogin.AddLoginAsync(login);
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
