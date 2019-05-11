using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        public async Task<List<Review>> GetMovieReview(string q)
        {
            try
            {
                var getResponse = await $"https://192.168.1.15:45457/api/ReviewTask/{q}".GetJsonAsync<List<Review>>();
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
