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
    public class HomePetsController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [Route("api/GetHomePetsProfile/{UserID}")]
        [HttpGet]
        public IHttpActionResult GetHomePetsProfile(string UserID)
        {
            try
            {

                var HomePets = context.HomePets.FirstOrDefault(cs => cs.UserId == UserID);
                var photos = context.HomePetsPhoto.Where(hs => hs.homePets.ID == HomePets.ID).ToList();
                HomePetDto cli = new HomePetDto
                {
                    ID = HomePets.ID,
                    AvailablePlace = HomePets.AvailablePlace,
                    Description = HomePets.Description,
                    NumberOfRooms = HomePets.NumberOfRooms,
                    PriceForNight = HomePets.PriceForNight,
                };
                foreach (var phot in photos)
                {
                    HomePetsPhotoDTo dTo = new HomePetsPhotoDTo
                    {
                        ID = phot.ID,
                        Photo = phot.Photo
                    };
                    cli.photos.Add(dTo);

                }

                return Ok(cli);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("api/EditHomePetsProfile")]
        [HttpPut]
        public IHttpActionResult EditHomePets([FromBody]HomePetDto homePetdto)
        {
            try
            {
                var updatedUser = context.HomePets.FirstOrDefault(hp => hp.ID == homePetdto.ID);
                if (updatedUser != null)
                {
                    updatedUser.Description = homePetdto.Description;
                    updatedUser.AvailablePlace = homePetdto.AvailablePlace;
                    updatedUser.NumberOfRooms = homePetdto.NumberOfRooms;
                    updatedUser.PriceForNight = homePetdto.PriceForNight;
                    context.SaveChanges();
                    return Ok("Successed");
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

        [Route("api/DeleteHomePetsPhoto/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteHomePetsPhoto(int Id)
        {
            try
            {
                var homepetsphoto = context.HomePetsPhoto.FirstOrDefault(hp => hp.ID == Id);
                context.HomePetsPhoto.Remove(homepetsphoto);
                context.SaveChanges();
                return Ok("Successed");
            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("api/AddHomePetsPhoto/{UserID}")]
        [HttpPost]
        public IHttpActionResult AddHomePetsPhoto(string UserID,[FromBody]List<HomePetsPhotoDTo> petDto)
        {
            try
            {
                var home = context.HomePets.FirstOrDefault(us => us.UserId == UserID);
                foreach (var photo in petDto)
                {
                    home.homePetsPhoto.Add(new HomePetsPhoto { homePetsID = home.ID, Photo = photo.Photo });
                }
                context.SaveChanges();
                return Ok("Successed");
            }
            catch
            {
                return BadRequest();
            }
        }

        ApplicationDbContext HomePets = new ApplicationDbContext();
        List<HomeModal> AllHome = new List<HomeModal>();

        private void searchResult(HomePets item)
        {
            HomeModal SingleHome = new HomeModal();
            var user = context.Users.FirstOrDefault(us => us.Id == item.UserId);
            SingleHome.ID = item.ID;
            SingleHome.Description = item.Description;
            SingleHome.AvailablePlace = item.AvailablePlace;
            SingleHome.NumberOfRooms = item.NumberOfRooms;
            SingleHome.PriceForNight = item.PriceForNight;

            SingleHome.User.Email = user.Email;
            SingleHome.User.Id = user.Id;
            SingleHome.User.PhoneNumber = user.PhoneNumber;
            SingleHome.User.Photo = user.Photo;
            SingleHome.User.FirstName = user.FirstName;
            SingleHome.User.UserName = user.UserName;
            foreach (var image in item.homePetsPhoto)
            {
                SingleHome.HomePhotos.Add(image.Photo);
            }
            AllHome.Add(SingleHome);
        }
        // GET: api/HomePets
        public IHttpActionResult Get()
        {

            var qery = (from c in HomePets.HomePets
                        select c).ToList();
            foreach (var item in qery)
            {
                searchResult(item);

            }
            return Json(AllHome);
        }


        [Route("api/HomePetsSearch")]
        [HttpGet]

        public IHttpActionResult SearchGet([FromUri]int? price, [FromUri]int? avaliable, [FromUri]string address)
        {
            List<HomeModal> AllHome = new List<HomeModal>();
            if (price == null && avaliable == null && address == "null")
            {

                var qery = (from c in HomePets.HomePets
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);

            }
            else if (price == null && avaliable == null)
            {
                var qery = (from c in HomePets.HomePets
                            where c.User.Address.Contains(address)
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);
            }
            else if (price == null && address == "null")
            {
                var qery = (from c in HomePets.HomePets
                            where c.AvailablePlace == avaliable
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);
            }
            else if (avaliable == null && address == "null")
            {
                var qery = (from c in HomePets.HomePets
                            where c.PriceForNight == price
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);
            }

            else if (avaliable == null)
            {
                var qery = (from c in HomePets.HomePets
                            where c.PriceForNight == price && c.User.Address.Contains(address)
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);
            }
            else if (address == "null")
            {
                var qery = (from c in HomePets.HomePets
                            where c.PriceForNight == price && c.PriceForNight == price
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);
            }
            else if (price == null)
            {
                var qery = (from c in HomePets.HomePets
                            where c.AvailablePlace == avaliable && c.User.Address.Contains(address)
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);

            }
            else
            {
                var qery = (from c in HomePets.HomePets
                            where c.PriceForNight == price && c.User.Address.Contains(address) && c.PriceForNight == price
                            select c).ToList();
                foreach (var item in qery)
                {
                    searchResult(item);
                }
                return Json(AllHome);

            }

        }
    }
}
