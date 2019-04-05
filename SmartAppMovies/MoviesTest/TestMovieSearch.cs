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
    public class TestMovieSearch
    {
        [TestMethod]
        public void MovieSearch()
        {
            using (var httpTest = new HttpTest())
            {
                var search = new SearchRepo();
                var result = search.GetMovieSearch("Guardians");
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<List<MovieSearch>>));
                httpTest.ShouldHaveCalled("http://www.omdbapi.com").WithVerb(HttpMethod.Get);
            }
        }
    }
}
