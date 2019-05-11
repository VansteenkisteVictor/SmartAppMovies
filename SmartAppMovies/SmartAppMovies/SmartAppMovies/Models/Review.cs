using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }
    }
}
