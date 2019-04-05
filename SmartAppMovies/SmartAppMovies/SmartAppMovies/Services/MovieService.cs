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
        public MovieService(ISearchRepo searchRepo,IDetailRepo detailRepo)
        {
            _searchRepo = searchRepo;
            _detailRepo = detailRepo;
        }
        public async Task<MovieSearch> GetMovieSearch(string q)
        {
            return await _searchRepo.GetMovieSearch(q);
        }
        public async Task<List<MovieDetail>> GetMovieDetail(string q)
        {
            return await _detailRepo.GetMovieDetail(q);
        }
    }
}
