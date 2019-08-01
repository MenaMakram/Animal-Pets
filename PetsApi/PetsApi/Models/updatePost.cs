using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class updatePost
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [DataType("Date")]
        public DateTime PostDateTime { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserImage { get; set; }
        public List<string> postPhotos { get; set; }
        public List<string> Comments { get; set; }
    }
}