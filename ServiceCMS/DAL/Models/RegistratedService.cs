﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RegistratedService
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int ServiceTypeId { get; set; }
        public int ServiceProviderId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }
        public ServiceType ServiceType { get; set; }

    }
}