using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.MenuViewModel
{
    public class CreateProductViewModel
    {
        [Required]
        [Display(Name = "Наименование")]
        public string NameOfProduct { get; set; }
        [Display(Name = "Превью")]
        public string HeadImage { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Скидка")]
        public int? Discount { get; set; }
        [Required]
        [Display(Name = "Активирован")]
        public bool IsVisible { get; set; }

        [Required]
        [Display(Name = "SEO Path")]
        public string UrlPath { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public Category Category { get; set; }

        public Product ToEntity()
        {
            return new Product
            {
                NameOfProduct =this.NameOfProduct,
                HeadImage = this.HeadImage,
                Price = this.Price,
                Discount = this.Discount,
                IsVisible = this.IsVisible,
                UrlPath = this.UrlPath,
                CategoryId = this.CategoryId,
                Category = this.Category
            };
        }
    }
}