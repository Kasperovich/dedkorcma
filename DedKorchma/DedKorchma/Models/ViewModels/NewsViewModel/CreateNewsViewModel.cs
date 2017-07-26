using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.Mvc;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.NewsViewModel
{
    public class CreateNewsViewModel
    {
        [Display(Name = "Заголовк")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "Текст")]
        public string Body { get; set; }
        public string HeadImage { get; set; }
        [Display(Name = "Активирован")]
        public bool IsDeleted { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "SEO Url")]
        public string UrlPath { get; set; }
        [Display(Name = "SEO Description")]
        public string Description { get; set; }
        [Display(Name = "SEO H1")]
        public string H1 { get; set; }

        public News ToEntity()
        {
            return new News
            {
                Name = this.Name,
                ShortDescription = this.ShortDescription,
                Body = this.Body,
                HeadImage = this.HeadImage,
                IsDeleted = this.IsDeleted,
                DateCreated = DateTime.Now,
                UrlPath = string.IsNullOrEmpty(this.UrlPath) ? String.Empty : this.UrlPath,

                Description = string.IsNullOrEmpty(this.Description) ? String.Empty : this.Description,
                H1 = string.IsNullOrEmpty(this.H1) ? String.Empty : this.H1,
                Title = string.IsNullOrEmpty(this.Title) ? String.Empty : this.Title
            };
        }
    }
}