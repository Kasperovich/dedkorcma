using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.NewsViewModel
{
    public class DetailsNewsViewModel
    {
        [Display(Name = "Заголовк")]
        public string Name { get; set; }
        [AllowHtml]
        [Display(Name = "Текст")]
        public string Body { get; set; }
        public string HeadImage { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "SEO Url")]
        public string UrlPath { get; set; }
        [Display(Name = "SEO Description")]
        public string Description { get; set; }
        [Display(Name = "SEO H1")]
        public string H1 { get; set; }

        public DetailsNewsViewModel(News news)
        {
            Name = news.Name;
            Body = news.Body;
            HeadImage = news.HeadImage;
            DateCreated = news.DateCreated;
            Title = news.Title;
        }
    }
}