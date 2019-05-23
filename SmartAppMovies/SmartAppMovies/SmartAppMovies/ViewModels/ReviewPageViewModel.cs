using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartAppMovies.ViewModels
{
    public class ReviewPageViewModel: ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public ReviewPageViewModel(IMovieService movieService,ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            GetRating(0);

        }

        private double _sliderValue;
        public double SliderValue
        {
            get
            {
                return _sliderValue;
            }
            set
            {
                _sliderValue = value;
                RaisePropertyChanged(() => SliderValue);
                GetRating(SliderValue);
            }
        }

        private MovieDetail _selectedMovie;
        public MovieDetail SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                _selectedMovie = value;
                RaisePropertyChanged(() => SelectedMovie);

            }
        }

        //private Review _review;
        //public Review Review
        //{
        //    get
        //    {
        //        return _review;
        //    }
        //    set
        //    {
        //        _review = value;
        //        RaisePropertyChanged(() => Review);
        //    }
        //}


        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                RaisePropertyChanged(() => Comment);
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

        public void GetRating(double SliderValue)
        {
            switch ((int)SliderValue)
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

        public RelayCommand AddReviewCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        string username = Preferences.Get("UserName", null); ;
                        Login user = await _movieService.GetLogin(username);
                        PostReview review = new PostReview();
                        review.Name = user.Username;
                        review.Comment = Comment;
                        decimal slider = Math.Round(Convert.ToDecimal(SliderValue));
                        int slider2 = Convert.ToInt32(slider);
                        review.Score = slider2;
                        review.MovieId = SelectedMovie.imdbID;
                        review.Id = Guid.NewGuid(); 
                        review.UserId = user.Id.ToString();
                        await _movieService.PostReview(review);
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
