using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DedKorchma.BL;
using DedKorchma.BL.Service;
using DedKorchma.Models.Entities;
using DedKorchma.Models.ViewModels.Common;
using DedKorchma.Models.ViewModels.NewsViewModel;

namespace DedKorchma.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index(int pageNumber=1)
        {
            var pagination = new PaginationParameters { Page = pageNumber };
                var model = new IndexViewModel(NewsService.GetAll(pagination,Request.IsAuthenticated))
                {
                    Pagination = new PaginationViewModel
                    {
                        PageNumber = pagination.Page,
                        PageSize = pagination.PageSize,
                        TotalItems = pagination.TotalCount,
                        Url = "/news"
                    }
                };
                return View(model);
        }

        public ActionResult GetLastNewsPartial()
        {
            var news = NewsService.GetLastNews()
                .Select(n => new NewsViewModel(n))
                .ToList();
            return PartialView("_GetLastNews", news);
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNews(CreateNewsViewModel news)
        {
            if (!ModelState.IsValid) return View(news);

            if (NewsService.Create(news.ToEntity()))
            {
                return RedirectToAction("Index", "News");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditNews(int id)
        {
            try
            {
                var news = NewsService.GetbyId(id);
                return View(new EditNewsViewModel(news));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditNews(EditNewsViewModel news)
        {
            if (!ModelState.IsValid) return View(news);
            if (NewsService.Update(news.ToEntity()))
            {
                return RedirectToAction("Index", "News");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteNews(string newsId)
        {
            try
            {
                if (NewsService.Delete(Convert.ToInt32(newsId)))
                {
                    return RedirectToAction("Index", "News");
                }
                return View();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult DetailsNews(string url)
        {
            try
            {
                var news = NewsService.GetbyUrl(url);
                return View(new DetailsNewsViewModel(news));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult SaveNewsPhoto()
        {
            var pathNewsPhoto = System.Configuration.ConfigurationManager.AppSettings["pathNewsPhoto"];
            var location = Server.MapPath($"~{pathNewsPhoto}");
            string[] filePaths = Directory.GetFiles(location);

            //foreach (var oldFile in filePaths)
            //{
            //    System.IO.File.Delete(oldFile);
            //}

            var isSavedSuccessfully = true;
            var fName = "";

            try
            {
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];
                    var filename =
                        $"news-photo-{DateTime.Now:yy-MM-dd-HH-mm-ss-fff}-{Guid.NewGuid()}-{file.ContentLength}{Path.GetExtension(file.FileName)}";

                    fName = filename;

                    filename = Path.Combine(location, filename);

                    bool isExists = Directory.Exists(location);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(location);

                    file.SaveAs(filename);
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }

            return isSavedSuccessfully
                ? Json(new
                {
                    uploaded = 1,
                    fileName = fName,
                    url = System.Configuration.ConfigurationManager.AppSettings["pathNewsPhoto"] + fName
                })
                : Json(new { uploaded = 0, Message = "Ошибка загрузки файла" });
        }


    }
}