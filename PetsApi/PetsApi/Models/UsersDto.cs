using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsApi.Models
{
    public class UsersDto
    {
        public string ID { get; set; }
        [Required]

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Doctor Dto
        public bool HasClinic { get; set; }
        public virtual string doctorClinics { get; set; }
        //Home Pets
        public string Description { get; set; }
        public int AvailablePlace { get; set; }
        public int NumberOfRooms { get; set; }
        [DataType("money")]
        public decimal PriceForNight { get; set; }
        //tranier
        public string JobTitle { get; set; }
        public string Overview { get; set; }
        public string Courses { get; set; }
        public string TrainePlace { get; set; }
        [DataType("money")]
        public decimal PricePerHour { get; set; }
        //type user
        public string TypeRegistration { get; set; }

    }
}