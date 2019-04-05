using GalaSoft.MvvmLight;
using SmartAppMovies.Models;
using SmartAppMovies.Repositories;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class MainPageViewModel :ViewModelBase
    {
        private readonly IMovieService _movieService;
        public MainPageViewModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async void GetDataAsync(string search)
        {
            try
            {
                movieSearch = await _movieService.GetMovieSearch(search);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            

            Console.WriteLine(movieSearch.Search[0].Poster);
        }

        private MovieSearch _moviesSearch;
        public MovieSearch movieSearch
        {
            get
            {
                return _moviesSearch;
            }
            set
            {
                _moviesSearch = value;
                RaisePropertyChanged(() => movieSearch);
            }
        }

        private ErrorMessage _errorMessage;
        public ErrorMessage errorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if(value != null)
                {
                    _errorMessage = value;
                    RaisePropertyChanged(() => errorMessage);
                }

            }
        }

        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                if(value != null && value.Length > 3)
                {
                    try
                    {
                        _search = value;
                        RaisePropertyChanged(() => Search);
                        GetDataAsync(Search);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

            }
        }
    }
}
