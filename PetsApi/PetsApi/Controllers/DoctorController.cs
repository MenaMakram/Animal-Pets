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
    public class DoctorController : ApiController
    {
        ApplicationDbContext doctor = new ApplicationDbContext();
        List<DoctorModel> AllDoctor = new List<DoctorModel>();

        private void getall()
        {
            var qery = (from c in doctor.Doctor
                        select new { c.ID, c.HasClinic, c.UserID }).ToList();
            foreach (var doctorId in qery)
            {
                var SingleDoctor = (from doctors in doctor.Users
                                    where doctors.Id == doctorId.UserID
                                    select doctors).FirstOrDefault();
                if (!doctorId.HasClinic)
                {
                    DoctorModel singleModel = new DoctorModel();
                    singleModel.ID = doctorId.ID;
                    singleModel.HasClinic = doctorId.HasClinic;
                    singleModel.user.Email = SingleDoctor.Email;
                    singleModel.user.Id = SingleDoctor.Id;
                    singleModel.user.PhoneNumber = SingleDoctor.PhoneNumber;
                    singleModel.user.Photo = SingleDoctor.Photo;
                    singleModel.user.FirstName = SingleDoctor.FirstName;
                    singleModel.user.UserName = SingleDoctor.UserName;

                    singleModel.clinic = null;
                    AllDoctor.Add(singleModel);

                }
                else
                {
                    DoctorModel singleModel = new DoctorModel();
                    singleModel.ID = doctorId.ID;
                    singleModel.HasClinic = doctorId.HasClinic;
                    var clinicID = (from DoctorClinics in doctor.doctorClinics where DoctorClinics.DoctorID == doctorId.ID select DoctorClinics.clinic).ToList();
                    foreach (var Clinics in clinicID)
                    {
                        DoctorDetails single = new DoctorDetails();
                        single.ClinicAddress = Clinics.Address;
                        single.ClinicName = Clinics.Name;
                        single.ClinicPhone = Clinics.Phone;
                        single.StartDate = Clinics.StartDate;
                        single.EndDate = Clinics.EndDate;
                        single.EndTime = Clinics.EndTime.ToString();
                        single.StartTime = Clinics.StartTime.ToString();

                        singleModel.clinic.Add(single);

                    }
                    singleModel.user.Email = SingleDoctor.Email;
                    singleModel.user.Id = SingleDoctor.Id;
                    singleModel.user.PhoneNumber = SingleDoctor.PhoneNumber;
                    singleModel.user.Photo = SingleDoctor.Photo;
                    singleModel.user.FirstName = SingleDoctor.FirstName;
                    singleModel.user.UserName = SingleDoctor.UserName;
                    AllDoctor.Add(singleModel);


                }

            }
        }
        // GET: api/Doctor
        public IHttpActionResult Get()
        {
            getall();
            return Json(AllDoctor);
        }


        [Route("api/DoctorSearch")]
        [HttpGet]

        public IHttpActionResult SearchGet([FromUri]string Name, [FromUri] string address)
        {

            if (address == "null" && Name == "null")
            {
                getall();
                return Json(AllDoctor);
            }


            else if (Name == "null")
            {
                var qery = (from c in doctor.Doctor
                            select new { c.ID, c.HasClinic, c.UserID }).ToList();
                DoctorModel singleModel = new DoctorModel();
                var searchDoctor = (from doctors in doctor.Doctor
                                    where doctors.HasClinic == true
                                    select doctors).ToList();

                foreach (var doctorId in searchDoctor)
                {
                    singleModel.ID = doctorId.ID;
                    singleModel.HasClinic = doctorId.HasClinic;
                    singleModel.user.Email = doctorId.user.Email;
                    singleModel.user.Id = doctorId.user.Id;
                    singleModel.user.PhoneNumber = doctorId.user.PhoneNumber;
                    singleModel.user.Photo = doctorId.user.Photo;
                    singleModel.user.FirstName = doctorId.user.FirstName;
                    singleModel.user.UserName = doctorId.user.UserName;

                    var clinicID = (from DoctorClinics in doctor.doctorClinics
                                    where DoctorClinics.clinic.Address.Contains(address)
                                    select DoctorClinics).ToList();
                    if (clinicID.Count != 0)
                    {
                        List<DoctorDetails> doc = new List<DoctorDetails>();
                        foreach (var Clinics in clinicID)
                        {


                            DoctorDetails single = new DoctorDetails();
                            single.ClinicAddress = Clinics.clinic.Address;
                            single.ClinicName = Clinics.clinic.Name;
                            single.ClinicPhone = Clinics.clinic.Phone;
                            single.StartDate = Clinics.clinic.StartDate;
                            single.EndDate = Clinics.clinic.EndDate;
                            single.EndTime = Clinics.clinic.EndTime.ToString();
                            single.StartTime = Clinics.clinic.StartTime.ToString();
                            doc.Add(single);

                        }
                        singleModel.clinic = doc;
                        AllDoctor.Add(singleModel);
                    }
                    else
                    {
                        AllDoctor = null;
                        return Json(AllDoctor);
                    }
                }
                return Json(AllDoctor);

            }
            else if (address == "null")
            {
                var searchDoctor = (from doctors in doctor.Doctor
                                    where doctors.user.UserName.Contains(Name)
                                    select doctors).ToList();

                if (searchDoctor.Count == 0)
                {
                    AllDoctor = null;
                    return Json(AllDoctor);
                }
                foreach (var doctorId in searchDoctor)
                {
                    DoctorModel singleModel = new DoctorModel();
                    singleModel.ID = doctorId.ID;
                    singleModel.HasClinic = doctorId.HasClinic;
                    singleModel.user.Email = doctorId.user.Email;
                    singleModel.user.Id = doctorId.user.Id;
                    singleModel.user.PhoneNumber = doctorId.user.PhoneNumber;
                    singleModel.user.Photo = doctorId.user.Photo;
                    singleModel.user.FirstName = doctorId.user.FirstName;
                    singleModel.user.UserName = doctorId.user.UserName;

                    if (!doctorId.HasClinic)
                    {
                        AllDoctor.Add(singleModel);
                    }
                    else
                    {
                        var clinicID = (from DoctorClinics in doctor.doctorClinics where DoctorClinics.DoctorID == doctorId.ID select DoctorClinics).ToList();

                        List<DoctorDetails> doc = new List<DoctorDetails>();
                        foreach (var Clinics in clinicID)
                        {
                            Clinic SingleClinic = (from Clinic in doctor.Clinics
                                                   where Clinic.ID == Clinics.ClinicID
                                                   select Clinic).FirstOrDefault();

                            DoctorDetails single = new DoctorDetails();
                            single.ClinicAddress = SingleClinic.Address;
                            single.ClinicName = SingleClinic.Name;
                            single.ClinicPhone = SingleClinic.Phone;
                            single.StartDate = SingleClinic.StartDate;
                            single.EndDate = SingleClinic.EndDate;
                            single.EndTime = SingleClinic.EndTime.ToString();
                            single.StartTime = SingleClinic.StartTime.ToString();

                            doc.Add(single);

                        }
                        singleModel.clinic = doc;
                        AllDoctor.Add(singleModel);
                    }
                }
                return Json(AllDoctor);
            }
            else
            {

                var searchDoctor = (from doctors in doctor.Doctor
                                    where doctors.user.UserName.Contains(Name)
                                    select doctors).ToList();
                if (searchDoctor.Count == 0)
                {
                    AllDoctor = null;
                    return Json(AllDoctor);
                }
                foreach (var doctorId in searchDoctor)
                {
                    DoctorModel singleModel = new DoctorModel();
                    singleModel.ID = doctorId.ID;
                    singleModel.HasClinic = doctorId.HasClinic;

                    singleModel.user.Email = doctorId.user.Email;
                    singleModel.user.Id = doctorId.user.Id;
                    singleModel.user.PhoneNumber = doctorId.user.PhoneNumber;
                    singleModel.user.Photo = doctorId.user.Photo;
                    singleModel.user.FirstName = doctorId.user.FirstName;
                    singleModel.user.UserName = doctorId.user.UserName;


                    if (!doctorId.HasClinic)
                    {
                        singleModel = null;
                    }
                    else
                    {
                        var clinicID = (from DoctorClinics in doctor.doctorClinics where DoctorClinics.clinic.Address.Contains(address) select DoctorClinics).ToList();
                        if (clinicID.Count != 0)
                        {
                            List<DoctorDetails> doc = new List<DoctorDetails>();
                            foreach (var Clinics in clinicID)
                            {


                                DoctorDetails single = new DoctorDetails();
                                single.ClinicAddress = Clinics.clinic.Address;
                                single.ClinicName = Clinics.clinic.Name;
                                single.ClinicPhone = Clinics.clinic.Phone;
                                single.StartDate = Clinics.clinic.StartDate;
                                single.EndDate = Clinics.clinic.EndDate;
                                single.EndTime = Clinics.clinic.EndTime.ToString();
                                single.StartTime = Clinics.clinic.StartTime.ToString();
                                doc.Add(single);

                            }
                            singleModel.clinic = doc;
                            AllDoctor.Add(singleModel);
                        }
                        else
                        {
                            AllDoctor = null;
                            return Json(AllDoctor);
                        }
                    }

                }
                return Json(AllDoctor);
            }

        }
    }
}
