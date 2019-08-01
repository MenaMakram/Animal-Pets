using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class DoctorDto
    {
        public bool HasClinic { get; set; }
        public List<ClinicDto> Clinics { get; set; } = new List<ClinicDto>();
    }
    public class ClinicDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}