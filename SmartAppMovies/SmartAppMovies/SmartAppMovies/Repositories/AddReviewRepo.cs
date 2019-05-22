using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class AddReviewRepo : IAddReviewRepo
    {
        public async Task AddReview(PostReview review)
        {
            try
            {
                Console.WriteLine(review);
                var getResponse = await "https://192.168.233.98:45456/api/ReviewTask".PostJsonAsync(review);

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
