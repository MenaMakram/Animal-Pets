using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Doctor
    {
        public int ID { get; set; }
        public bool HasClinic { get; set; }
        [ForeignKey("user")]
        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<DoctorClinics> doctorClinics { get; set; } = new List<DoctorClinics>();
       

    }
}
