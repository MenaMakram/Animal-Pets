using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Animals
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int age { get; set; }
        public bool status { get; set; }
        public int MarriedCount { get; set; }
        public string Description { get; set; }
        public int SonsCount { get; set; }
        public decimal MarriedSalary { get; set; }
        public bool AvailableMarried { get; set; }
        public bool AvailableForBill { get; set; }

        [ForeignKey("clients")]
        public int? ClientID { get; set; }
        public virtual Clients clients { get; set; }

        [ForeignKey("category")]
        public int? CategoryID { get; set; }
        public virtual Category category { get; set; }

        public virtual ICollection<AnimalsPhoto> animalsPhoto { get; set; } = new List<AnimalsPhoto>();
    }
}
