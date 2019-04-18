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
                if (DetailMovie.Metascore != null && DetailMovie.Metascore != "N/A")
                {
                    float FloatRating = (float.Parse(DetailMovie.Metascore, CultureInfo.InvariantCulture.NumberFormat) / 100) * 5;
                    GetRatingMetaScore(FloatRating);
                }
                else
                {
                    Rating = "data6.json";
                }
                if(DetailMovie.imdbRating != null && DetailMovie.imdbRating != null)
                {
                    float FloatRating = (float.Parse(DetailMovie.imdbRating) / 10) * 5;
                    GetRatingIMDB(FloatRating);
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

        public void GetRatingMetaScore(float FloatRating)
        {

            Console.Write(float.Parse(DetailMovie.Metascore));
            
            switch((int)FloatRating)
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
            Console.WriteLine(Rating);
        }

        public void GetRatingIMDB(float FloatRating)
        {
            switch ((int)FloatRating)
            {
                case 1:
                    Rating2 = "data1.json";
                    break;
                case 2:
                    Rating2 = "data2.json";
                    break;
                case 3:
                    Rating2 = "data3.json";
                    break;
                case 4:
                    Rating2 = "data4.json";
                    break;
                case 5:
                    Rating2 = "data5.json";
                    break;
                default:
                    Rating2 = "data6.json";
                    break;
            }
            Console.WriteLine(Rating2);
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
