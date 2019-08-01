using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class AnimalsDetails
    {
        public AnimalModel animals { get; set; } = new AnimalModel();
        public bool status { get; set; }
        public int MarriedCount { get; set; }
        public int SonsCount { get; set; }
        public decimal MarriedSalary { get; set; }
        public bool AvailableMarried { get; set; }
        public bool AvailableForBill { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}