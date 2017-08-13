using DedKorchma.BL.Infrastructure;
using DedKorchma.DAL.Interface;
using DedKorchma.DAL.Repository;
using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DedKorchma.BL.Service
{
    public class GalleryService
    {
        public static IList<Album> GetAll()
        {
            var pathGellaryPhoto = ConfigurationManager.AppSettings["pathGalleryPhoto"];
            var pathDefaultPhoto = ConfigurationManager.AppSettings["pathDefaultPhoto"];
            IGalleryRepository galleryRepo = new GalleryRepository();
            var albums = galleryRepo.GetAll().ToList();
            foreach(var album in albums)
            {
                if (album.HeadImage != "" && album.HeadImage != null)
                {
                    album.HeadImage = pathGellaryPhoto + album.HeadImage;
                }
                else
                {
                    album.HeadImage = pathDefaultPhoto;
                }
            }
            return albums;
        }

        public static Album GetByName(string url)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            var album = galleryRepo.GetByName(url);
            if (album == null)
            {
                throw new NotFoundException("Альбом не найден", "");
            }
            return album;
        }
        public static bool CreateAlbum(Album album)
        {
            IGalleryRepository galleryrepo = new GalleryRepository();
            return galleryrepo.CreateAlbum(album);
        }
    }
}