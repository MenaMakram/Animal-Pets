using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class DoctorDetails
    {
        public string ClinicName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClinicPhone { get; set; }
        public string ClinicAddress { get; set; }


    }
}