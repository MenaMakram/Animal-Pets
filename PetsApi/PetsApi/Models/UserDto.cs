using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
    }
}