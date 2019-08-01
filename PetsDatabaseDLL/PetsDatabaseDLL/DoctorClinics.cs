using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class DoctorClinics
    {
        public int ID { get; set; }
        [ForeignKey("doctor")]
        public int? DoctorID { get; set; }
        public virtual Doctor doctor { get; set; }
        [ForeignKey("clinic")]
        public int? ClinicID { get; set; }
        public virtual Clinic clinic { get; set; }
    }
}
