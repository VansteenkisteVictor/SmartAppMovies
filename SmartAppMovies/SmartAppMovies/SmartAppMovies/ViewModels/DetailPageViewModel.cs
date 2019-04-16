using GalaSoft.MvvmLight;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class DetailPageViewModel: ViewModelBase
    {
        private readonly IMovieService _movieService;
        public DetailPageViewModel(IMovieService movieService)
        {
            _movieService = movieService;
            
        }

        private Search _selectedMovie;
        public Search SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                _selectedMovie = value;
                RaisePropertyChanged(() => SelectedMovie);
                GetDataAsync(SelectedMovie.Title);
            }
        }

        private MovieDetail _detailMovie;
        public MovieDetail DetailMovie
        {
            get
            {
                return _detailMovie;
            }
            set
            {
                _detailMovie = value;
                RaisePropertyChanged(() => DetailMovie);
            }
        }

        public async void GetDataAsync(string name)
        {
            try
            {
                DetailMovie = await _movieService.GetMovieDetail(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
