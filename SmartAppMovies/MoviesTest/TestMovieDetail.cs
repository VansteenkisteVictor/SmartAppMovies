using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartAppMovies.Models;
using SmartAppMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTest
{
    [TestClass]
    public class TestMovieDetail
    {
        [TestMethod]
        public void MovieDetail()
        {
            using (var httpTest = new HttpTest())
            {
                var detail = new DetailRepo();
                var result = detail.GetMovieDetail("Guardians of the Galaxy");
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<List<MovieDetail>>));
                httpTest.ShouldHaveCalled("http://www.omdbapi.com").WithVerb(HttpMethod.Get);
            }
        }
    }
}
