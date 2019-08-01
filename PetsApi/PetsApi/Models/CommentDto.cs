using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class CommentDto
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string UserPhoto { get; set; }

    }
}