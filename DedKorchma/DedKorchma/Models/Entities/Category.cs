using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string NameOfCategory { get; set; }
        public string NameOfCategoryLat { get; set; }
        public string HeadImage { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string H1 { get; set; }

        public List<Product> Products { get; set; }
        public Category()
        {
            Products=new List<Product>();
        }

    }
}