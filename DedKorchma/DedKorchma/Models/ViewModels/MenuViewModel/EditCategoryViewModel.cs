using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.MenuViewModel
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string NameOfCategory { get; set; }
        [Required]
        [Display(Name = "Название на латинице")]
        public string NameOfCategoryLat { get; set; }
        public string HeadImage { get; set; }

        [Required]
        [Display(Name = "SEO Title")]
        public string Title { get; set; }
        [Display(Name = "SEO Description")]
        public string Description { get; set; }
        [Display(Name = "SEO H1")]
        public string H1 { get; set; }

        public EditCategoryViewModel(Category category)
        {
            Id = category.Id;
            NameOfCategory = category.NameOfCategory;
            NameOfCategoryLat = category.NameOfCategoryLat;
            HeadImage = category.HeadImage;
            Title = category.Title;
            Description = category.Description;
            H1 = category.H1;
        }
        public Category ToEntity()
        {
            return new Category
            {
                Id = this.Id,
                NameOfCategory = this.NameOfCategory,
                NameOfCategoryLat = this.NameOfCategoryLat,
                HeadImage = this.HeadImage,
                Title = this.Title,
                Description = this.Description,
                H1 = this.H1
            };
        }
    }
}