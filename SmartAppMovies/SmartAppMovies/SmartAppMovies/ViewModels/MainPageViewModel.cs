using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Repositories;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartAppMovies.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public MainPageViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            
            _movieService = movieService;
            _navigationService = navigationService;
            ImgVis = true;
            ListVis = true;
            GetPersonalAsync();

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

        public RelayCommand RefreshReviewsCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        await GetPersonalAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand LogOutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        Preferences.Remove("UserName");
                        _navigationService.GoBack();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand ManageReviews
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.ManageReviews, MyReviews);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetPersonalAsync()
        {
            try
            {
                string id = Preferences.Get("ID", null);
                List<Review> ReviewsTemp = await _movieService.GetUserReview(id);
                foreach(Review review in ReviewsTemp)
                {
                    MovieDetail movie = await _movieService.GetMovieDetail(review.MovieId);
                    review.MyMovie = movie;
                }
                MyReviews = ReviewsTemp;
            }
            catch (Exception ex)
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
                //if(value.Response != "False")
                //{
                //    ImgVis = false;
                //    ListVis = true;
                //}
                if (value.Response == "True")
                {
                    ImgVis = false;
                    ListVis = true;
                }
                else
                {
                    ImgVis = true;
                    ListVis = false;
                }
            }
        }

        private bool _imgVis;
        public bool ImgVis
        {
            get
            {
                return _imgVis;
            }
            set
            {
                _imgVis = value;
                RaisePropertyChanged(() => movieSearch);
            }
        }
        private bool _listVis;
        public bool ListVis
        {
            get
            {
                return _listVis;
            }
            set
            {
                _listVis = value;
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
                if (value != null)
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
                if (value != null && value.Length > 3)
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

        private Review _mySelectedReview;
        public Review MySelectedReview
        {
            get { return _mySelectedReview; }
            set
            {
                if(value != null)
                {
                    _mySelectedReview = value;
                    RaisePropertyChanged(() => MySelectedReview);
                    try
                    {
                        Search search = new Search();
                        search.Title = _mySelectedReview.MyMovie.Title;
                        search.Poster = _mySelectedReview.MyMovie.Poster;
                        search.Type = _mySelectedReview.MyMovie.Type;
                        search.Year = _mySelectedReview.MyMovie.Year;
                        search.imdbID = _mySelectedReview.MyMovie.imdbID;
                        _navigationService.NavigateTo(ViewModelLocator.DetailPage, search);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        private List<Review> _myReviews;
        public List<Review> MyReviews
        {
            get { return _myReviews; }
            set
            {
                Console.Write(_myReviews);
               _myReviews = value;
               RaisePropertyChanged(() => MyReviews);
            }
        }
    
    }
}

