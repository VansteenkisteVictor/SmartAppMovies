﻿using GalaSoft.MvvmLight.Ioc;
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
        public const string Review = "Review";
        public const string AllReviews = "AllReviews";

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<DetailPageViewModel>();
            SimpleIoc.Default.Register<ReviewPageViewModel>();
            SimpleIoc.Default.Register<AllReviewsPageViewModel>();
            SimpleIoc.Default.Register<IDetailRepo, DetailRepo>();
            SimpleIoc.Default.Register<ISearchRepo, SearchRepo>();
            SimpleIoc.Default.Register<IMovieService, MovieService>();
            SimpleIoc.Default.Register<IReviewRepo, ReviewRepo>();
            SimpleIoc.Default.Register<IAddReviewRepo, AddReviewRepo>();
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

        public ReviewPageViewModel ReviewPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ReviewPageViewModel>();
            }
        }

        public AllReviewsPageViewModel AllReviewsPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AllReviewsPageViewModel>();
            }
        }


    }
}
