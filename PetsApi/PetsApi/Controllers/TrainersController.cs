using PetsApi.Models;
using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetsApi.Controllers
{
    public class TrainersController : ApiController
    {
        ApplicationDbContext Trainers = new ApplicationDbContext();
        List<TrainerDto> Traines = new List<TrainerDto>();

        private void getTrainer(Trainer item)
        {
            TrainerDto SingleTrainers = new TrainerDto();
            SingleTrainers.Courses = item.Courses;
            SingleTrainers.ID = item.ID;
            SingleTrainers.JobTitle = item.JobTitle;
            SingleTrainers.Overview = item.Overview;
            SingleTrainers.PricePerHour = item.PricePerHour;
            SingleTrainers.TrainePlace = item.TrainePlace;
            SingleTrainers.user.Email = item.user.Email;
            SingleTrainers.user.Id = item.user.Id;
            SingleTrainers.user.PhoneNumber = item.user.PhoneNumber;
            SingleTrainers.user.Photo = item.user.Photo;
            SingleTrainers.user.FirstName = item.user.FirstName;
            SingleTrainers.user.UserName = item.user.UserName;
            Traines.Add(SingleTrainers);

        }
        // GET: api/Trainers
        public IHttpActionResult Get()
        {
            var qery = (from c in Trainers.Trainers
                        select c).ToList();
            foreach (var item in qery) {
                getTrainer(item);
            }

            return Json(Traines);
        }
        [Route("api/TrainerSearch")]
        [HttpGet]

        public IHttpActionResult SearchGetall([FromUri]int? price, [FromUri]string Course, string address)
        {
            if (price == null && address == "null" && Course == "null")
            {
                var qery = (from c in Trainers.Trainers
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);

            }
            else if (price == null && Course == "null")
            {
                var qery = (from c in Trainers.Trainers
                            where c.TrainePlace.Contains(address)
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }
            else if (price == null && address == "null")
            {
                var qery = (from c in Trainers.Trainers
                            where c.Courses.Contains(Course)
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }
            else if (Course == "null" && address == "null")
            {
                var qery = (from c in Trainers.Trainers
                            where c.PricePerHour == price
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }

            else if (Course == "null")
            {
                var qery = (from c in Trainers.Trainers
                            where c.PricePerHour == price && c.TrainePlace.Contains(address)
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }
            else if (address == "null")
            {
                var qery = (from c in Trainers.Trainers
                            where c.PricePerHour == price && c.Courses.Contains(Course)
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);

            }
            else if (price == null)
            {
                var qery = (from c in Trainers.Trainers
                            where c.TrainePlace.Contains(address) && c.Courses.Contains(Course)
                            select c).ToList();

                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }
            else
            {
                var qery = (from c in Trainers.Trainers
                            where (c.PricePerHour == price && c.TrainePlace.Contains(address) && c.Courses.Contains(Course))
                            select c).ToList();
                foreach (var item in qery)
                {
                    getTrainer(item);
                }

                return Json(Traines);
            }

        }

    }
}
