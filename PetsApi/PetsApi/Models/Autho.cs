using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class AuthBusinessLayer
    {
        ApplicationDbContext context = new ApplicationDbContext();
        UserManager<ApplicationUser> manager;
        public AuthBusinessLayer()
        {
            manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        //public IdentityResult Create(string Username,string Password)
        //{
        //    IdentityUser user = new IdentityUser();
        //    user.UserName = Username;
        //    user.PasswordHash = Password; 
        //    return manager.Create(user,Password);
        //}


        public IdentityResult Create(UsersDto user)
        {
            ApplicationUser userIDen = new ApplicationUser();
            userIDen.UserName = user.UserName;
            userIDen.FirstName = user.FirstName;
            userIDen.Email = user.Email;
            userIDen.PhoneNumber = user.Phone;
            userIDen.PasswordHash = user.Password;
            userIDen.Address = user.Address;
            userIDen.LastName = user.LastName;
            userIDen.Photo = user.Photo;
            userIDen.UserType = 4;

            if (user.TypeRegistration == "Doctor")
            {
                userIDen.UserType =3;
                IdentityResult result = manager.Create(userIDen, user.Password);
                manager.AddToRole(userIDen.Id, "Doctor");
                if (result.Succeeded)
                {
                    Doctor doctor = new Doctor();
                    doctor.UserID = userIDen.Id;
                    doctor.HasClinic = user.HasClinic;
                    Clinic clinic = context.Clinics.FirstOrDefault(n => n.Name == user.doctorClinics);
                    if (clinic != null)
                    {
                        DoctorClinics doctorClinics = new DoctorClinics();
                        doctorClinics.ClinicID = clinic.ID;
                        doctorClinics.DoctorID = doctor.ID;
                        doctor.doctorClinics.Add(doctorClinics);
                    }
                    else
                    {
                        Clinic cs = new Clinic();
                        cs.Name = user.doctorClinics;
                        context.Clinics.Add(cs);
                        DoctorClinics doctorClinics = new DoctorClinics();
                        doctorClinics.ClinicID = cs.ID;
                        doctorClinics.DoctorID = doctor.ID;
                        context.doctorClinics.Add(doctorClinics);
                    }
                    context.Doctor.Add(doctor);
                    context.SaveChanges();
                }
                return result;
            }

            else if (user.TypeRegistration == "House")
            {
                userIDen.UserType = 2;

                IdentityResult result = manager.Create(userIDen,user.Password);
                context.SaveChanges();

                //context.SaveChanges();
                if (result.Succeeded)
                {

                    manager.AddToRole(userIDen.Id, "House");
                    HomePets homePets = new HomePets();
                    homePets.AvailablePlace = user.AvailablePlace;
                    homePets.NumberOfRooms = user.NumberOfRooms;
                    homePets.PriceForNight = user.PriceForNight;
                    homePets.Description = user.Description;
                    homePets.UserId = userIDen.Id;
                    context.HomePets.Add(homePets);
                    context.SaveChanges();
                }
                return result;

            }
            else if (user.TypeRegistration == "Trainer")
            {
                userIDen.UserType = 1;
                IdentityResult result = manager.Create(userIDen, user.Password);
                if (result.Succeeded)
                {
                    manager.AddToRole(userIDen.Id, "Trainer");
                    Trainer trainer = new Trainer();
                    trainer.Courses = user.Courses;
                    trainer.JobTitle = user.JobTitle;
                    trainer.TrainePlace = user.TrainePlace;
                    trainer.Overview = user.Overview;
                    trainer.UserID = userIDen.Id;
                    context.Trainers.Add(trainer);
                    context.SaveChanges();
                }
                return result;
            }
            else
            {
                IdentityResult result = manager.Create(userIDen,userIDen.PasswordHash);
                if (result.Succeeded)
                {
                manager.AddToRoles(userIDen.Id, user.TypeRegistration);

                    manager.AddToRole(userIDen.Id, "Client");
                    Clients client = new Clients();
                    client.UserID = userIDen.Id;
                    context.Clinets.Add(client);
                    context.SaveChanges();
                }
                return result;
            }
        }


        public IdentityUser Find(string UserName, string pass)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Where(u => u.UserName == UserName).FirstOrDefault(u => u.PasswordHash == pass);

            return user;


        }

    }
}