using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Models.ViewModels;
using Scheduling.Services;
using Scheduling.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Scheduling.Controllers.Api
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppointmentService _appointmentservice;
        private readonly string loginUserId;
        private readonly string role;
        public AppointmentApiController(IAppointmentService appointmentService,
                                        IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _appointmentservice = appointmentService;

            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        [Route("CalendarData")]
        public IActionResult SaveCalendarData(AppointmentVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _appointmentservice.AddUpdate(data).Result;
                if (commonResponse.status == 1) 
                    commonResponse.message = Helper.appointmentUpdated;
                if (commonResponse.status == 2) 
                    commonResponse.message = Helper.appointmentAdded;
            }
            catch(Exception e)
            {
                commonResponse.message = e.Message;
            }
            return Ok(commonResponse);
        }

    }
}
