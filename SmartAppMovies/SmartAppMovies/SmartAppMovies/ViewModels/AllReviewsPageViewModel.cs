using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class AllReviewsPageViewModel:ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public AllReviewsPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
        }

        private List<Review> _reviews;
        public List<Review> Reviews
        {
            get
            {
                return _reviews;
            }
            set
            {
                _reviews = value;
                RaisePropertyChanged(() => Reviews);

            }
        }
    }
}
