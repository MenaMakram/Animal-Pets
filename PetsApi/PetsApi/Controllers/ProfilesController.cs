using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PetsDatabaseDLL;
using PetsApi.Models;


namespace PetsApi.Controllers
{
    [Authorize]
    public class ProfilesController : ApiController
    { 
        ApplicationDbContext context = new ApplicationDbContext();
        
        [HttpGet]
        [Route("api/GetUserProfile/{UserID}")]
        public IHttpActionResult GetUserProfile(string UserID)
        {
            try
            {
                var user = context.Users.FirstOrDefault(us => us.Id == UserID);
                if (user != null)
                {
                    UserDto us = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        Email = user.Email,
                        Phone = user.PhoneNumber,
                        Photo = user.Photo,
                        UserType=user.UserType
                    };
                    return Ok(us);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/GetClientProfile/{UserID}")]
        public IHttpActionResult GetClientProfile(string UserID)
        {
            
            var client = context.Clinets.FirstOrDefault(cs => cs.UserID == UserID);
            var Animals = context.Animals.Where(an => an.ClientID == client.ID).ToList();
            ClientDto cli = new ClientDto();
            foreach (var ani in Animals)
            {
                AnimalDto ad = new AnimalDto
                {
                    ID=ani.ID,
                    Name = ani.Name,
                    age = ani.age,
                    AvailableForBill=ani.AvailableForBill,
                    AvailableMarried=ani.AvailableMarried,
                    CategoryID=int.Parse(ani.CategoryID.ToString()),
                    Description=ani.Description,
                    Gender=ani.Gender,
                    MarriedCount=ani.MarriedCount,
                    MarriedSalary=ani.MarriedSalary,
                    SonsCount=ani.SonsCount,
                    CategoryName=ani.category.Name,
                    status=ani.status,
                    Type=ani.Type,
                };
                foreach (var adp in ani.animalsPhoto)
                {
                    AnimalPhotoDto apd = new AnimalPhotoDto
                    {
                        ID=adp.ID,
                        Image=adp.Image
                    };
                    ad.animalPhoto.Add(apd);
                }
                cli.Animals.Add(ad);

            }
            return Ok(cli);
        }
        [HttpGet]
        [Route("api/GetDoctorProfile/{UserID}")]
        public IHttpActionResult GetDoctorProfile(string UserID)
        {
            try
            {
                
                var Doctor = context.Doctor.FirstOrDefault(cs => cs.UserID == UserID);
                var doctorclinic = context.doctorClinics.Where(dc => dc.DoctorID == Doctor.ID).ToList();
                DoctorDto cli = new DoctorDto
                {
                    HasClinic = Doctor.HasClinic
                };
                if (Doctor.HasClinic)
                {
                    foreach (var item in doctorclinic)
                    {
                        var Clinics = context.Clinics.FirstOrDefault(cs => cs.ID == item.ClinicID);
                        if (Clinics != null)
                        {
                            ClinicDto ccd = new ClinicDto();
                            ccd.ID = Clinics.ID;
                            ccd.Name = Clinics.Name;
                            ccd.Address = Clinics.Address;
                            ccd.Phone = Clinics.Phone;
                            ccd.StartDate = Clinics.StartDate;
                            ccd.EndDate = Clinics.EndDate;
                            ccd.StartTime = Clinics.StartTime;
                            ccd.EndTime = Clinics.EndTime;
                            cli.Clinics.Add(ccd);
                        }

                    }
                }
                return Ok(cli);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

       

        [HttpGet]
        [Route("api/GetTrainerProfile/{UserID}")]
        public IHttpActionResult GetTrainersProfile(string UserID)
        {
            try
            {
                
                var Trainer = context.Trainers.FirstOrDefault(ts => ts.UserID == UserID);
                if (Trainer != null)
                {
                    TrainerDto trainerDto = new TrainerDto
                    {
                        ID = Trainer.ID,
                        Courses = Trainer.Courses,
                        JobTitle = Trainer.JobTitle,
                        Overview = Trainer.Overview,
                        PricePerHour = Trainer.PricePerHour,
                        TrainePlace = Trainer.TrainePlace
                    };
                    return Ok(trainerDto);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            { return BadRequest(); }
        }
        [HttpPut]
        [Route("api/EditUserProfile")]
        public IHttpActionResult EditProfile([FromBody]UserDto user)
        {
            var usrUpdated = context.Users.FirstOrDefault(us => us.Id == user.Id);
            if(usrUpdated != null)
            {
                try
                {
                    usrUpdated.FirstName = user.FirstName;
                    usrUpdated.LastName = user.LastName;
                    usrUpdated.Email = user.Email;
                    usrUpdated.Address = user.Address;
                    usrUpdated.PhoneNumber = user.Phone;
                    context.SaveChanges();
                    return Ok("Successed");
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("api/UserProfilePhoto/{userID}")]
        public IHttpActionResult UpdateUserPhoto(string userID,[FromBody]UserDto user)
        {
            var usrUpdated = context.Users.FirstOrDefault(us => us.Id == userID);
            if (usrUpdated != null)
            {
                try
                {
                    usrUpdated.Photo = user.Photo;
                    context.SaveChanges();
                    return Ok("Successed");
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }

        }
        [Route("api/EditTrainerProfile")]
        [HttpPut]
        public IHttpActionResult EditTrainer([FromBody]Trainer trainer)
        {
            var usrUpdated = context.Trainers.FirstOrDefault(us => us.ID == trainer.ID);
            if (usrUpdated != null)
            {
                try
                {
                    usrUpdated.JobTitle = trainer.JobTitle;
                    usrUpdated.Overview = trainer.Overview;
                    usrUpdated.PricePerHour = trainer.PricePerHour;
                    usrUpdated.TrainePlace = trainer.TrainePlace;
                    usrUpdated.Courses = trainer.Courses;
                    //usrUpdated.Photo = user.Photo;
                    context.SaveChanges();
                    return Ok("Successed");
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }

        }






    }
}
