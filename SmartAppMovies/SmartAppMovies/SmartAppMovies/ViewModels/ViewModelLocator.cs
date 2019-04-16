using GalaSoft.MvvmLight.Ioc;
using SmartAppMovies.Repositories;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.ViewModels
{
    public class ViewModelLocator
    {
        public const string MainPage = "MainPage";
        public const string DetailPage = "DetailPage";

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<DetailPageViewModel>();
            SimpleIoc.Default.Register<IDetailRepo, DetailRepo>();
            SimpleIoc.Default.Register<ISearchRepo, SearchRepo>();
            SimpleIoc.Default.Register<IMovieService, MovieService>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainPageViewModel>();
            }
        }

        public DetailPageViewModel DetailPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<DetailPageViewModel>();
            }
        }

    }
}
