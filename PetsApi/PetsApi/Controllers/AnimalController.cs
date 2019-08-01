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
    public class AnimalController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpPost]
        [Route("api/InsertAnimal/{Id}")]
        public IHttpActionResult InsertAnimal(string Id, [FromBody]AnimalDto animals)
        {
            try
            {
                Animals animal = new Animals();
                var clientId = context.Clinets.FirstOrDefault(us => us.UserID == Id).ID;
                if (animal != null)
                {
                    animal.Name = animals.Name;
                    animal.age = animals.age;
                    animal.AvailableForBill = animals.AvailableForBill;
                    animal.AvailableMarried = animals.AvailableMarried;
                    animal.CategoryID = animals.CategoryID;
                    animal.Description = animals.Description;
                    animal.Gender = animals.Gender;
                    animal.MarriedSalary = animals.MarriedSalary;
                    animal.MarriedCount = animals.MarriedCount;
                    animal.SonsCount = animals.SonsCount;
                    animal.status = animals.status;
                    animal.Type = animals.Type;
                    animal.ClientID = clientId;
                    foreach (var item in animals.animalPhoto)
                    {
                        AnimalsPhoto ap = new AnimalsPhoto { AnimalID = animal.ID, Image = item.Image };
                        animal.animalsPhoto.Add(ap);
                    }
                    context.Animals.Add(animal);
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
        [HttpPut]
        [Route("api/UpdateAnimal/{Id}")]
        public IHttpActionResult UpdateAnimal(int Id,[FromBody]AnimalDto animals)
        {
            try
            {
                var animal = context.Animals.FirstOrDefault(dc => dc.ID == Id);
                if (animal != null)
                {
                    animal.Name = animals.Name;
                    animal.age = animals.age;
                    animal.AvailableForBill = animals.AvailableForBill;
                    animal.AvailableMarried = animals.AvailableMarried;
                    animal.CategoryID = animals.CategoryID;
                    animal.Description = animals.Description;
                    animal.Gender = animals.Gender;
                    animal.MarriedSalary = animals.MarriedSalary;
                    animal.MarriedCount = animals.MarriedCount;
                    animal.SonsCount = animals.SonsCount;
                    animal.status = animals.status;
                    animal.Type = animals.Type;
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
        [HttpDelete]
        [Route("api/DeleteAnimal/{Id}")]
        public IHttpActionResult DeleteAnimal(int Id)
        {
            try
            {
                var animal = context.Animals.FirstOrDefault(dc => dc.ID == Id);
                if (animal != null)
                {

                     context.Animals.Remove(animal);
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

        [HttpGet]
        [Route("api/GetGategory")]
        public IHttpActionResult GetGategory()
        {
            try
            {
                var category = context.Categories.ToList();
                List<CategoryDto> catlist = new List<CategoryDto>();
                foreach (var item in category)
                {
                    catlist.Add(new CategoryDto { ID = item.ID, Name = item.Name, Image = item.Image });
                }
                return Ok(catlist);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/DeletePhoto/{Id}")]
        public IHttpActionResult DeletePhoto(int Id)
        {
            try
            {
                var photo = context.AnimalPhotos.FirstOrDefault(ph => ph.ID == Id);
                context.AnimalPhotos.Remove(photo);
                context.SaveChanges();
                return Ok("Successed");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("api/AddPhoto/{Id}")]
        public IHttpActionResult AddPhoto(int Id,[FromBody]List<AnimalPhotoDto> photos)
        {
            try
            {
                var animal = context.Animals.FirstOrDefault(an => an.ID == Id);
                foreach (var photo in photos)
                {
                    AnimalsPhoto app = new AnimalsPhoto
                    {
                        Image = photo.Image,
                        AnimalID=animal.ID
                    };
                    animal.animalsPhoto.Add(app);
                }
                context.SaveChanges();
                return Ok("Successed");
            }
            catch
            {
                return BadRequest();
            }
        }

        ApplicationDbContext Animals = new ApplicationDbContext();
        List<AnimalModel> AllAnimal = new List<AnimalModel>();
        private void getSingle(Animals Animal)
        {

            AnimalModel Sanimal = new AnimalModel();
            Sanimal.age = Animal.age;
            Sanimal.category = Animal.category.Name;
            Sanimal.Gender = Animal.Gender;
            Sanimal.Description = Animal.Description;
            Sanimal.ID = Animal.ID;
            Sanimal.Type = Animal.Type;
            Sanimal.Name = Animal.Name;
            Sanimal.user.Address = Animal.clients.user.Address;

            Sanimal.user.Email = Animal.clients.user.Email;
            Sanimal.user.Id = Animal.clients.user.Id;
            Sanimal.user.PhoneNumber = Animal.clients.user.PhoneNumber;
            Sanimal.user.Photo = Animal.clients.user.Photo;
            Sanimal.user.FirstName = Animal.clients.user.FirstName;
            Sanimal.user.UserName = Animal.clients.user.UserName;


            foreach (var image in Animal.animalsPhoto)
            {
                Sanimal.AnimalPhotos.Add(image.Image);
            }
            AllAnimal.Add(Sanimal);
        }
        // GET: api/Animal
        public IHttpActionResult Get()
        {
            var query = (from animals in Animals.Animals
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }

        [Route("api/SearchGetAll")]
        [HttpGet]
        public IHttpActionResult SearchGet([FromUri]int age, [FromUri]int MarriedCount, [FromUri]string address, string category, string type, string gander)
        {

            var query = (from animals in Animals.Animals
                         where (animals.age == age && animals.MarriedCount == MarriedCount
                         && animals.clients.user.Address.Contains(address) && animals.category.Name.Contains(category)
                         && animals.Type.Contains(type) && animals.Gender.Contains(gander))
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }
        [Route("api/SearchGetAge")]
        [HttpGet]
        public IHttpActionResult SearchGetAge([FromUri]int age)
        {

            var query = (from animals in Animals.Animals
                         where animals.age == age
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }
        [Route("api/SearchGetMarr")]
        [HttpGet]
        public IHttpActionResult SearchGetMarr([FromUri]int MarriedCount)
        {

            var query = (from animals in Animals.Animals
                         where (animals.MarriedCount == MarriedCount)
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }
        [Route("api/SearchGetaddress")]
        [HttpGet]
        public IHttpActionResult SearchGetaddress([FromUri]string address)
        {

            var query = (from animals in Animals.Animals
                         where animals.clients.user.Address.Contains(address)
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }
        [Route("api/SearchGetcategory")]
        [HttpGet]
        public IHttpActionResult SearchGetcategory(string category)
        {

            var query = (from animals in Animals.Animals
                         where animals.category.Name.Contains(category)
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }
        [Route("api/SearchGettype")]
        [HttpGet]
        public IHttpActionResult SearchGettype(string type)
        {

            var query = (from animals in Animals.Animals
                         where animals.Type.Contains(type)
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);

        }
        [Route("api/SearchGetgander")]
        [HttpGet]
        public IHttpActionResult SearchGetgander(string gander)
        {

            var query = (from animals in Animals.Animals
                         where animals.Gender.Contains(gander)
                         select animals).ToList();
            foreach (var Animal in query)
            {
                getSingle(Animal);
            }

            return Json(AllAnimal);
        }


    }

}

