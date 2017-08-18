using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.GalleryViewModel
{
    public class EditAlbumViewModel
    {
        public int AlbumId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string NameOfAlbum { get; set; }
        [Display(Name = "Прeвью")]
        public string HeadImage { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата создания")]
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

        public EditAlbumViewModel(Album album)
        {
            AlbumId = album.Id;
            NameOfAlbum = album.NameOfAlbum;
            HeadImage = album.HeadImage;
            UrlPath = album.UrlPath;
            Title = album.Title;
            Description = album.Description;
            Keywords = album.Keywords;
            Photos = album.Photos;
        }

        public EditAlbumViewModel() { }
        public Album ToEntity()
        {
            return new Album
            {
                Id = this.AlbumId,
                NameOfAlbum = this.NameOfAlbum,
                HeadImage = this.HeadImage,
                DateCreated = this.DateCreated,
                UrlPath = this.UrlPath,
                Title = this.Title,
                Description = this.Description,
                Keywords = this.Keywords,
                Photos = this.Photos
            };
        }
    }
}