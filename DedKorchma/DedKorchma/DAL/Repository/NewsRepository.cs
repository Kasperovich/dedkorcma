﻿using System;
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
    public class NewsRepository : INewsRepository
    {
        public IList<News> GetAll()
        {
            using (var context = new ContextDb())
            {
                return GetAll(context);
            }
        }

        internal IList<News> GetAll(ContextDb context)
        {
            return context.News.OrderByDescending(n => n.DateCreated).ToList();
        }

        public IList<News> GetAll(PaginationParameters pagination)
        {
            using (var context = new ContextDb())
            {
                return GetAll(context,pagination);
            }
        }

        internal IList<News> GetAll(ContextDb context,PaginationParameters pagination)
        {
            var news = context.News
                .OrderByDescending(n => n.DateCreated)
                .Skip((pagination.Page - 1)*pagination.PageSize)
                .Take(pagination.PageSize).ToList();
            pagination.TotalCount = context.News.Count();
            return news;
        }

        public IList<News> GetAllActivated(PaginationParameters pagination)
        {
            using (var context=new ContextDb())
            {
                return GetAllActivated(context, pagination);
            }
        }

        internal IList<News> GetAllActivated(ContextDb context, PaginationParameters pagination)
        {
            var news = context.News
                .OrderByDescending(n => n.DateCreated)
                    .Where(n => n.IsDeleted)
                .Skip((pagination.Page - 1)*pagination.PageSize)
                .Take(pagination.PageSize)
            .ToList();
            pagination.TotalCount = context.News.Count(n=>n.IsDeleted);
            return news;
        }

        public bool Create(News news)
        {
            using (var context=new ContextDb())
            {
                return Create(context, news);
            }
        }

        internal bool Create(ContextDb context, News news)
        {
            context.News.Add(news);
            return context.SaveChanges() == 1;
        }

        public bool Update(News news)
        {
            using (var context=new ContextDb())
            {
                return Update(context, news);
            }
        }

        internal bool Update(ContextDb context, News news)
        {
            DbEntityEntry<News> entry = context.Entry(news);
            entry.State =EntityState.Modified;
            return context.SaveChanges() == 1;
        }

        public News GetbyId(int id)
        {
            using (var context = new ContextDb())
            {
                return GetbyId(context, id);
            }
        }
        internal News GetbyId(ContextDb context, int id)
        {
            return context.News.SingleOrDefault(n => n.Id == id);
        }

        public News GetbyUrl(string url)
        {
            using (var context=new ContextDb())
            {
                return GetbyUrl(context, url);
            }
        }

        internal News GetbyUrl(ContextDb context, string url)
        {
            return context.News.SingleOrDefault(n => n.UrlPath == url);
        }

        public bool Delete(int id)
        {
            using (var context = new ContextDb())
            {
                return Delete(context, id);
            }
        }

        internal bool Delete(ContextDb context, int id)
        {
            var news = context.News.Find(id);
            DbEntityEntry<News> entry = context.Entry(news);
            entry.State = EntityState.Deleted;
            return context.SaveChanges() == 1;
        }
    }
}