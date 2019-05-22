using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class ManageReviewsPageViewModel: ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public ManageReviewsPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
        }

        private List<Models.Review> _userReviews;
        public List<Models.Review> UserReviews
        {
            get
            {
                return _userReviews;
            }
            set
            {
                _userReviews = value;
                RaisePropertyChanged(() => UserReviews);
                //if(UserReviews != null)
                //{
                //    ManageAllow = true;
                //}
                //else
                //{
                //    ManageAllow = false;
                //}
            }
        }

        private Review _mySelectedReview;
        public Review MySelectedReview
        {
            get { return _mySelectedReview; }
            set
            {
                _mySelectedReview = value;
                RaisePropertyChanged(() => MySelectedReview);
            }
        }

        //private bool _manageAllow;
        //public bool ManageAllow
        //{
        //    get { return _manageAllow; }
        //    set
        //    {
        //        _manageAllow = value;
        //        RaisePropertyChanged(() => ManageAllow);
        //    }
        //}

        public RelayCommand DeleteCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _movieService.DeleteReview(MySelectedReview.Id.ToString());
                        _navigationService.GoBack();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.UpdateReview,_mySelectedReview);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }
    }
}
