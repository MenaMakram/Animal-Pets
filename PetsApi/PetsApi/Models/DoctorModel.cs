using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetsDatabaseDLL;

namespace PetsApi.Models
{
    public class DoctorModel
    {
        public int ID { get; set; }
        public bool HasClinic { get; set; }
        public virtual user user { get; set; } = new user();
        public List<DoctorDetails> clinic { get; set; } = new List<DoctorDetails>();
    }
}