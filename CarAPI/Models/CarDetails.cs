using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Models
{
    public class CarDetails
    {
        [Key]
        public int PMId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CarModel { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]

        public string CarMake { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]

        public string Color { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Licenseplate { get; set; }



    }
}
