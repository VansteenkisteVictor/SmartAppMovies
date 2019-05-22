﻿using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class GetUserReview : IGetUserReview
    {
        public async Task<List<Review>> GetUserReviewAsync(string q)
        {
            try
            {
                Console.Write($"https://192.168.233.98:45456/api/ReviewTask/userreview/{q}");
                var getResponse = await $"https://192.168.233.98:45456/api/ReviewTask/userreview/{q}".GetJsonAsync<List<Review>>();
                Console.WriteLine(getResponse);
                return getResponse;
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
