﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = Helper.Admin,
                    Text = Helper.Admin,
                },
                new SelectListItem
                {
                    Value = Helper.Patient,
                    Text = Helper.Patient,
                },
                new SelectListItem
                {
                    Value = Helper.Doctor,
                    Text = Helper.Doctor,
                },
            };
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int mins=30; mins <= 30*24; mins+=30)
            {
                duration.Add(new SelectListItem
                {
                    Value = mins.ToString(),
                    Text = $"{mins/60} hr {mins%60} mins"
                });
            };
            return duration;
        }
    }
}
