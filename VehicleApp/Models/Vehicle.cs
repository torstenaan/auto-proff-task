using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleApp.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Range(0,int.MaxValue, ErrorMessage = "Distance must be positive.")]
        public int Distance { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be positive.")]
        public int Price { get; set; }
    }
}
