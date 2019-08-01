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
    public class ClinicController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Route("api/EditClinic")]
        [HttpPut]
        public IHttpActionResult EditClinic([FromBody]ClinicDto clinicDto)
        {
            try
            {
                var updatedUser = context.Clinics.FirstOrDefault(hp => hp.ID == clinicDto.ID);
                if (updatedUser != null)
                {
                    updatedUser.Name = clinicDto.Name;
                    updatedUser.Phone = clinicDto.Phone;
                    updatedUser.StartDate = clinicDto.StartDate;
                    updatedUser.EndDate = clinicDto.EndDate;
                    updatedUser.StartTime = clinicDto.StartTime;
                    updatedUser.EndTime = clinicDto.EndTime;
                    updatedUser.Address = clinicDto.Address;
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
        [Route("api/AddClinic/{UserID}")]
        [HttpPost]
        public IHttpActionResult AddClinic(string UserID, [FromBody]ClinicDto clinicDto)
        {
            try
            {
                var doctor = context.Doctor.FirstOrDefault(dc => dc.UserID == UserID);
                if (clinicDto != null)
                {
                    Clinic cli = new Clinic();
                    cli.Name = clinicDto.Name;
                    cli.Phone = clinicDto.Phone;
                    cli.StartDate = clinicDto.StartDate;
                    cli.EndDate = clinicDto.EndDate;
                    cli.StartTime = clinicDto.StartTime;
                    cli.EndTime = clinicDto.EndTime;
                    cli.Address = clinicDto.Address;
                    context.Clinics.Add(cli);
                    doctor.HasClinic = true;
                    doctor.doctorClinics.Add(new DoctorClinics { ClinicID = cli.ID });
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
        [Route("api/DeleteClinic/{UserID}")]
        [HttpPut]
        public IHttpActionResult DeleteClinic(string UserID, [FromBody]int clinicID)
        {
            try
            {
                var doctor = context.Doctor.FirstOrDefault(dc => dc.UserID == UserID);
                if (doctor != null)
                {

                    var cli = context.Clinics.FirstOrDefault(c => c.ID == clinicID);
                    var docCli = context.doctorClinics.FirstOrDefault(dc => dc.DoctorID == doctor.ID && dc.ClinicID == clinicID);
                    context.doctorClinics.Remove(docCli);
                    context.Clinics.Remove(cli);
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
    }
}
