using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DedKorchma.BL;
using DedKorchma.DAL.Interface;
using DedKorchma.Migrations;
using DedKorchma.Models.Entities;

namespace DedKorchma.DAL.Repository
{
    public class GalleryRepository:IGalleryRepository
    {
        public IList<Album> GetAll()
        {
            using(var context=new ContextDb())
            {
                return GetAll(context);
            }
        }
        internal IList<Album> GetAll(ContextDb context)
        {
            return context.Albums.Include(a => a.Photos).ToList();
        }
        public Album GetById(int id)
        {
            using(var context=new ContextDb())
            {
                return GetById(context, id);
            }
        }
        internal Album GetById(ContextDb contet,int id)
        {
            return contet.Albums.Include(a => a.Photos).SingleOrDefault(a => a.Id == id);
        }
        public Album GetByURL(string url)
        {
            using(var context=new ContextDb())
            {
                return GetByURL(context, url);
            }
        }

        internal Album GetByURL(ContextDb context,string url)
        {
            return context.Albums.Include(a => a.Photos).SingleOrDefault(a => a.UrlPath == url);
        }
        public bool CreateAlbum(Album album)
        {
            using(var context=new ContextDb())
            {
                return CreateAlbum(album, context);
            }
        }
        internal bool CreateAlbum(Album album,ContextDb context)
        {
            context.Albums.Add(album);
            return context.SaveChanges() == 1;
        }

        public bool SavePhotoInAlbum(AlbumPhoto photo)
        {
            using(var context=new ContextDb())
            {
                return SavePhotoInAlbum(context, photo);
            }
        }

        internal bool SavePhotoInAlbum(ContextDb context,AlbumPhoto photo)
        {
            context.AlbumPhotos.Add(photo);
            return context.SaveChanges() == 1;
        }

        public List<AlbumPhoto> GetPhotoInAlbum(int albumId)
        {
            using(var context=new ContextDb())
            {
                return GetPhotoInAlbum(context, albumId);
            }
        }

        internal List<AlbumPhoto> GetPhotoInAlbum(ContextDb context,int albumId)
        {
            return context.AlbumPhotos.Include(a=>a.Album).Where(a=>a.AlbumId==albumId).ToList();
        }

        public bool EditAlbum(Album album)
        {
            using(var context=new ContextDb())
            {
                return EditAlbum(context,album);
            }
        }

        internal bool EditAlbum(ContextDb context,Album album)
        {
            DbEntityEntry<Album> entry = context.Entry(album);
            entry.State = EntityState.Modified;
            return context.SaveChanges() == 1;
        }
    }
}