using GalaSoft.MvvmLight;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class PreferencesViewModel:ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public PreferencesViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;

        }
    }
}
