using Flurl.Http;
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
                var getResponse = await $"https://192.168.1.15:45457/api/ReviewTask/userreview/{q}".GetJsonAsync<List<Review>>();
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
