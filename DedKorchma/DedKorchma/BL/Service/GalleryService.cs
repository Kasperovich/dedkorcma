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
                foreach(var photo in album.Photos)
                {
                    photo.Path = pathGellaryPhoto+photo.Path;
                }
            }
            return albums;
        }

        public static Album GetById(int albumId)
        {
            var pathGalleryPhoto = ConfigurationManager.AppSettings["pathGalleryPhoto"];
            IGalleryRepository galleryRepo = new GalleryRepository();
            var album = galleryRepo.GetById(albumId);
            if (album == null)
            {
                throw new NotFoundException("Альбом не найден", "");
            }
            foreach (var photo in album.Photos)
            {
                photo.Path = pathGalleryPhoto + photo.Path;
            }
            return album;
        }

        public static Album GetByURL(string url)
        {
            var pathGalleryPhoto = ConfigurationManager.AppSettings["pathGalleryPhoto"];
            IGalleryRepository galleryRepo = new GalleryRepository();
            var album = galleryRepo.GetByURL(url);
            if (album == null)
            {
                throw new NotFoundException("Альбом не найден", "");
            }
            foreach (var photo in album.Photos)
            {
                photo.Path = pathGalleryPhoto + photo.Path;
            }
            return album;
        }
        public static bool CreateAlbum(Album album)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            return galleryRepo.CreateAlbum(album);
        }

        public static bool SavePhotoInAlbum(AlbumPhoto photo)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            return galleryRepo.SavePhotoInAlbum(photo);
        }

        public static List<AlbumPhoto> GetPhtotoInAlbum(int albumId)
        {
            var pathGellaryPhoto = ConfigurationManager.AppSettings["pathGalleryPhoto"];
            IGalleryRepository galleryRepo = new GalleryRepository();
            var photos= galleryRepo.GetPhotoInAlbum(albumId);
            foreach (var photo in photos)
            {
                photo.Path = pathGellaryPhoto + photo.Path;
            }
            return photos;
        }

        public static bool EditAlbum(Album album)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            return galleryRepo.EditAlbum(album);
        }

        public static bool DeleteAlbum(int albumId)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            return galleryRepo.DeleteAlbum(albumId);
        }

        public static bool DeletePhoto(int photoId)
        {
            IGalleryRepository galleryRepo = new GalleryRepository();
            return galleryRepo.DeletePhoto(photoId);
        }
    }
}