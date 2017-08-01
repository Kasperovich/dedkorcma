using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DedKorchma.BL;
using DedKorchma.Models.Entities;

namespace DedKorchma.DAL.Interface
{
    public interface INewsRepository
    {
        IList<News> GetAll();
        IList<News> GetAll(PaginationParameters pagination);
        IList<News> GetAllActivated(PaginationParameters pagination);
        bool Create(News news);
        News GetbyId(int id);
        News GetbyUrl(string url);
        bool Update(News news);
        bool Delete(int id);
    }
}