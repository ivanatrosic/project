﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.MVC.Models
{
    public class VehicleModelData
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}