using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.GalleryViewModel
{
    public class CreateAlbumViewModel
    {
        [Required]
        [Display(Name ="Название")]
        public string NameOfAlbum { get; set; }
        [Display(Name ="Прeвью")]
        public string HeadImage { get; set;}
        public DateTime? DateCreated { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "SEO Path")]
        public string UrlPath { get; set; }
        [Required]
        [Display(Name = "SEO Title")]
        public string Title { get; set; }
        [Display(Name = "SEO Description")]
        public string Description { get; set; }
        [Display(Name = "SEO Keywords")]
        public string Keywords { get; set; }
        public List<AlbumPhoto> Photos { get; set; }

        public Album ToEntity()
        {
            return new Album
            {
                NameOfAlbum = this.NameOfAlbum,
                HeadImage = this.HeadImage,
                DateCreated = DateTime.Now,
                UrlPath = this.UrlPath,
                Title = this.Title,
                Description = this.Description,
                Keywords = this.Keywords,
                Photos = this.Photos
            };
        }
    }
}