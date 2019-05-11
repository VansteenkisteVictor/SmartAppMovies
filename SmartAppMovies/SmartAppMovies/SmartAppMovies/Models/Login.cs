using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAppMovies.Models
{
    public class Login
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Admin { get; set; }
    }
}
