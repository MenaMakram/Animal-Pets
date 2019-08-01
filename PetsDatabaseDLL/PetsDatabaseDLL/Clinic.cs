using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Clinic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string StartDate { get; set; }
        
        public string EndDate { get; set; }

        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DoctorClinics> doctorClinics { get; set; } = new List<DoctorClinics>();

    }
}
