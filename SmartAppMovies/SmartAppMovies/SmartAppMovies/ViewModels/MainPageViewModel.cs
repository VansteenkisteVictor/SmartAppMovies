using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private ICustomNavigation _navigationService;
        public MainPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        GetDataAsync(Search);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
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

        private Search _selectedMovie;
        public Search SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (value != null)
                {
                    _selectedMovie = value;
                    RaisePropertyChanged(() => SelectedMovie);
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.DetailPage, _selectedMovie);
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
