using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string OpenAddress { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Location { get; set; }
    }
}