using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Barcode { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "BikeType")]
        public int BikeTypeId { get; set; }
        [ForeignKey("BikeTypeId")]
        [ValidateNever]
        public BikeType BikeType { get; set; }

        public string ImageUrl { get; set; }

    }
}
