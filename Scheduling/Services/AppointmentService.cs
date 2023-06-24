using Scheduling.Models;
using Scheduling.Models.ViewModels;
using Scheduling.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Services
{
    public class AppointmentService : IAppointmentService
    {
        public readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<DoctorVM> GetDoctorList()
        {
            var doctors = (from user in _db.Users
                           join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(x => x.Name == Helper.Doctor) on userRoles.RoleId equals roles.Id
                           select new DoctorVM { ID = user.Id, Name = user.Name }).ToList();
            return doctors;
        }

        public List<PatientVM> GetPatientList()
        {
            return (from user in _db.Users
                    join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                    join role in _db.Roles.Where(x => x.Name == Helper.Patient) on userRoles.RoleId equals role.Id
                    select new PatientVM
                    {
                        ID = user.Id,
                        Name = user.Name
                    }).ToList();
        }
    }
}
