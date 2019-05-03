using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SmartAppMovies.ViewModels
{
    public class DetailPageViewModel: ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public DetailPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            ButtonReviews = false;

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
                GetDataAsync(SelectedMovie.imdbID);
                GetReviewsAsync(SelectedMovie.imdbID);
                

            }
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
                Userrating = SetUserrating(Reviews);
                if(Userrating != 0 && Userrating != null)
                {
                    Rating3 = GetRatingUsers(Userrating); 
                }
                else
                {
                    Rating3 = "data6.json";
                }

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
                if (DetailMovie.Metascore != null && DetailMovie.Metascore != "N/A")
                {
                    float FloatRating = ((float.Parse(DetailMovie.Metascore) / 100) * 5)+1;
                    Rating =  GetRating(FloatRating);
                }
                else
                {
                    Rating = "data6.json";
                }
                if(DetailMovie.imdbRating != null && DetailMovie.imdbRating != null)
                {
                    float FloatRating = ((float.Parse(DetailMovie.imdbRating) / 10) * 5)+1;
                    Rating2 = GetRating(FloatRating);
                }
                else
                {
                    Rating2 = "data6.json";
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

        private string _rating2;
        public string Rating2
        {
            get
            {
                return _rating2;
            }
            set
            {
                _rating2 = value;
                RaisePropertyChanged(() => Rating2);
            }
        }

        private string _rating3;
        public string Rating3
        {
            get
            {
                return _rating3;
            }
            set
            {
                _rating3 = value;
                RaisePropertyChanged(() => Rating3);
            }
        }

        
        private int _userrating;
        public int Userrating
        {
            get
            {
                return _userrating;
            }
            set
            {
                _userrating = value;
                RaisePropertyChanged(() => Userrating);
            }
        }

        private bool _buttonreviews;
        public bool ButtonReviews
        {
            get
            {
                return _buttonreviews;
            }
            set
            {
                _buttonreviews = value;
                RaisePropertyChanged(() => ButtonReviews);
            }
        }

        public RelayCommand ReviewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.Review, DetailMovie);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand AllReviewsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.AllReviews, Reviews);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public string GetRating(float FloatRating)
        {
            switch((int)FloatRating)
            {
                case 1:
                    return "data1.json";
                case 2:
                    return "data2.json";
                case 3:
                    return "data3.json";
                case 4:
                    return "data4.json";
                case 5:
                    return "data5.json";
                default:
                    return "data6.json";
            }
        }

        public string GetRatingUsers(int IntRating)
        {
            switch (IntRating)
            {
                case 1:
                    return "data1.json";
                case 2:
                    return "data2.json";
                case 3:
                    return "data3.json";
                case 4:
                    return "data4.json";
                case 5:
                    return "data5.json";
                default:
                    return "data6.json";

            }
        }



        public async void GetDataAsync(string id)
        {
            try
            {
                DetailMovie = await _movieService.GetMovieDetail(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void GetReviewsAsync(string id)
        {
            try
            {
                Reviews = await _movieService.GetReview(id);
                if (Reviews.Count != 0)
                {
                    ButtonReviews = true;
                }
                else
                {
                    ButtonReviews = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int SetUserrating(List<Review> reviews)
        {
            if (reviews != null && reviews.Count != 0)
            {
                int sum = 0;
                for (int i = 0; i < reviews.Count; i++)
                {
                    sum += reviews[i].Score;
                }
                return sum / reviews.Count;
            }
            else
            {
                return 0;
            }

        }

        public async Task OpenBrowser(string uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }



        public RelayCommand WebsiteCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        if(DetailMovie.Website != null && DetailMovie.Website != "N/A")
                        {
                            await OpenBrowser(DetailMovie.Website);
                        }
                        else
                        {
                            await OpenBrowser("https://www.imdb.com/title/" + DetailMovie.imdbID);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }



        public RelayCommand ShareCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        await ShareText(DetailMovie.Title);
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
