﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace flights.Entity
{
    [Index(nameof(CountryID), Name = "IX_flights_CountryID")]
    public partial class flight
    {
        public flight()
        {
            airplanes = new HashSet<airplane>();
            tickets = new HashSet<ticket>();
        }

        [Key]
        public int FlightNumber { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableSeat { get; set; }
        public int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        [InverseProperty(nameof(country.flights))]
        public virtual country Country { get; set; }
        [InverseProperty(nameof(airplane.FlightNumberNavigation))]
        public virtual ICollection<airplane> airplanes { get; set; }
        [InverseProperty(nameof(ticket.FlightNumberNavigation))]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}