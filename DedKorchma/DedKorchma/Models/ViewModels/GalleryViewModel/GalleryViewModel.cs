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
       public List<AlbumPhoto> Photos { get; set; }

        public GalleryViewModel(List<Album> albums)
        {
            Albums = albums;
            var photos = new List<AlbumPhoto>();
            foreach (var item in albums)
            {
                foreach (var albumPhotos in item.Photos)
                {
                    photos.Add(albumPhotos);
                }
            }
            Photos = photos;
        }

        public GalleryViewModel() { }
    }
}