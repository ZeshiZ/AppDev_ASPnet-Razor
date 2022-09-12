
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class BikeType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Size of the bike")]
        [Range(10, 30, ErrorMessage="Size of a bike must be between 10 and 30")]
        public int? Size { get; set; }
    }
}
