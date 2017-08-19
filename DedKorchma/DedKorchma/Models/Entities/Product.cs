using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string NameOfProduct { get; set; }
        public string HeadImage { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        public bool IsVisible { get; set; }

        public string UrlPath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}