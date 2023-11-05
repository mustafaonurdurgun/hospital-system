using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
  
    public class AppointmentController : BaseCRUDController<Appointment, int, CreateAppointmentDTO, UpdateAppointmentDTO, AppointmentInfoDTo>
    {
        public AppointmentController(IAppointmentService service) : base(service)
        {
        }
    }
}
