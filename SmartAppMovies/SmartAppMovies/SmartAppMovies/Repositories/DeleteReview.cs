using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class DeleteReview : IDeleteReview
    {
        public async Task Delete(string q)
        {
            try
            {
                var getResponse = await $"https://192.168.233.98:45456/api/ReviewTask/delete/{q}".DeleteAsync();
                Console.WriteLine(getResponse);
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
