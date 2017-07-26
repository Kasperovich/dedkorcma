using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.NewsViewModel
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Заголовк")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "Текст")]
        public string Body { get; set; }
        [Required]
        [Display(Name = "Изображение")]
        public string HeadImage { get; set; }
        [Display(Name = "Активирован")]
        public bool IsDeleted { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy h:mm AM}")]
        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "SEO Url")]
        public string UrlPath { get; set; }
        [Display(Name = "SEO Description")]
        public string Description { get; set; }
        [Display(Name = "SEO H1")]
        public string H1 { get; set; }

        public NewsViewModel(News news)
        {
            Id = news.Id;
            Name = news.Name;
            ShortDescription = news.ShortDescription;
            HeadImage = news.HeadImage;
            IsDeleted = news.IsDeleted;
            UrlPath = news.UrlPath;
            Description = news.Description;
            H1 = news.H1;
            Title = news.Title;
            Body = news.Body;
            DateCreated = news.DateCreated;
        }

        public NewsViewModel()
        {
            
        }
    }
}