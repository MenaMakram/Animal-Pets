using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class Likes
    {
        public int postId { get; set; }
        public string userName { get; set; }
    }
}