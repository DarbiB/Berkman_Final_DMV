﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Berkman_Final_DMV.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            DriversInfractions = new HashSet<DriversInfraction>();
        }

        public string VehicleId { get; set; }
        public string DriverId { get; set; }
        public string VehiclePlate { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual ICollection<DriversInfraction> DriversInfractions { get; set; }
    }
}