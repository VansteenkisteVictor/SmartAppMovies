using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class UpdateReviewPageViewModel:ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public UpdateReviewPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
        }

        private Review _reviewUpdate;
        public Review ReviewUpdate
        {
            get
            {
                return _reviewUpdate;
            }
            set
            {
                _reviewUpdate = value;
                RaisePropertyChanged(() => ReviewUpdate);
                if(_reviewUpdate != null)
                {
                    GetRating(_reviewUpdate.Score);
                }

            }
        }

        private string _rating;
        public string Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged(() => Rating);
            }
        }

        public void GetRating(int score)
        {
            switch (score)
            {
                case 1:
                    Rating = "data1.json";
                    break;
                case 2:
                    Rating = "data2.json";
                    break;
                case 3:
                    Rating = "data3.json";
                    break;
                case 4:
                    Rating = "data4.json";
                    break;
                case 5:
                    Rating = "data5.json";
                    break;
                default:
                    Rating = "data6.json";
                    break;
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
                        PostReview postReview = new PostReview();
                        postReview.Name = ReviewUpdate.Name;
                        postReview.Comment = ReviewUpdate.Comment;
                        postReview.Score = ReviewUpdate.Score;
                        postReview.MovieId = ReviewUpdate.MovieId;
                        postReview.Id = ReviewUpdate.Id;
                        postReview.UserId = ReviewUpdate.UserId;

                        _movieService.UpdateReview(postReview);
                        _navigationService.GoBack();

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
