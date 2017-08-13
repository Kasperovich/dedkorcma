using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.GalleryViewModel
{
    public class GalleryViewModel
    {
       public List<Album> Albums { get; set; }
       public List<Photo> Photos { get; set; }

        public GalleryViewModel(List<Album> album)
        {
            Albums = album;
            foreach(var item in album)
            {
                foreach(var photo in item.Photos)
                {
                    Photos.Add(photo.Photo);
                }
            }
        }

        public GalleryViewModel() { }
    }
}