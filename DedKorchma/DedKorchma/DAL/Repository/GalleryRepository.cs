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
        public Album GetByName(string path)
        {
            using(var context=new ContextDb())
            {
                return GetByName(context, path);
            }
        }

        internal Album GetByName(ContextDb context,string url)
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
    }
}