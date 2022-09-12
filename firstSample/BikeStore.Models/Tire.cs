
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class Tire
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Size of the Tire")]
        [Range(10, 30, ErrorMessage="Size of a bike must be between 10 and 30")]
        public int? Size { get; set; }


        public string Color { get; set; }

        public int? Thickness { get; set; }
    }
}
