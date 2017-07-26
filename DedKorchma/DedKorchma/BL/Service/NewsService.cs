using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DedKorchma.BL.Infrastructure;
using DedKorchma.DAL.Interface;
using DedKorchma.DAL.Repository;
using DedKorchma.Models.Entities;

namespace DedKorchma.BL.Service
{
    public static class NewsService
    {
        public static IList<News> GetAll()
        {
            var pathNewsPhoto = ConfigurationManager.AppSettings["pathNewsPhoto"];
            var pathDefaultPhoto = ConfigurationManager.AppSettings["pathDefaultPhoto"];
            INewsRepository newsRepo = new NewsRepository();
            var allNews=  newsRepo.GetAll()
                .OrderByDescending(n => n.DateCreated)
                .ToList();
            foreach (var item in allNews)
            {
                if (item.HeadImage!="")
                {
                    item.HeadImage = pathNewsPhoto + item.HeadImage;
                }
                else
                {
                    item.HeadImage = pathDefaultPhoto;
                }
                
  
            }
            return allNews;
        }

        public static IList<News> GetLastNews()
        {
            INewsRepository newsRepo = new NewsRepository();
            var lastNews = new List<News>();
            var allNews = newsRepo.GetAll().Where(n=>n.IsDeleted).OrderByDescending(n => n.DateCreated).ToList();
            foreach (var item in allNews)
            {
                if (lastNews.Count >= 5) continue;
                lastNews.Add(item);
            }
            return lastNews;
        }

        public static bool Create(News news)
        {
            INewsRepository newsRepo=new NewsRepository();
            return newsRepo.Create(news);
        }

        public static News GetbyId(int id)
        {
            var pathNewsPhoto = ConfigurationManager.AppSettings["pathNewsPhoto"];
            INewsRepository newsRepo=new NewsRepository();
            var news= newsRepo.GetbyId(id);
            if (news == null)
            {
                throw new NotFoundException("Новость не найдена", "");
            }
            if (news.HeadImage != "")
            {
                news.HeadImage = pathNewsPhoto + news.HeadImage;
            }
            return news;
        }

        public static News GetbyUrl(string url)
        {
            var pathDefaultPhoto = ConfigurationManager.AppSettings["pathDefaultPhoto"];
            var pathNewsPhoto = ConfigurationManager.AppSettings["pathNewsPhoto"];
            INewsRepository newsRepo=new NewsRepository();
            var news = newsRepo.GetbyUrl(url);
            if (news == null)
            {
                throw new NotFoundException("Новость не найдена", "");
            }
            if (news.HeadImage != "")
            {
                news.HeadImage = pathNewsPhoto + news.HeadImage;
            }
            else
            {
                news.HeadImage = pathDefaultPhoto;
            }
            return news;
        }

        public static bool Update(News news)
        {
            INewsRepository newsRepo=new NewsRepository();
            var pathNewsPhoto = ConfigurationManager.AppSettings["pathNewsPhoto"];
            news.HeadImage = news.HeadImage.Replace(pathNewsPhoto, string.Empty);
            return newsRepo.Update(news);
        }

        public static bool Delete(int id)
        {
            INewsRepository newsRepo=new NewsRepository();
            return newsRepo.Delete(id);
        }
    }
}
