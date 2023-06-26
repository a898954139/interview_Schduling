﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duriation { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string AdminId { get; set; }
        public bool IsDoctorApproved { get; set; }
    }
}
