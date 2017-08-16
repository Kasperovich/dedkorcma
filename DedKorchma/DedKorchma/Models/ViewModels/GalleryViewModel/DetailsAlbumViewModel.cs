using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.GalleryViewModel
{
    public class DetailsAlbumViewModel
    {
        public int AlbumId { get; set; }
        public string NameOfAlbum { get; set; }
        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        public List<AlbumPhoto> Photos { get; set; }

        public DetailsAlbumViewModel(Album album)
        {
            AlbumId = album.Id;
            NameOfAlbum = album.NameOfAlbum;
            UrlPath = album.UrlPath;
            Title = album.Title;
            Description = album.Description;
            Keywords = album.Keywords;
            Photos = album.Photos;
        }

        public DetailsAlbumViewModel() { }
    }
}