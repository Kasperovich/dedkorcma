using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DedKorchma.BL;
using DedKorchma.BL.Service;
using DedKorchma.Controllers;
using DedKorchma.Models.ViewModels.Common;
using DedKorchma.Models.ViewModels.NewsViewModel;
using System.Configuration;

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
        [Authorize(Roles = "TechAdmin,Admin")]
        [HttpGet]
        public ActionResult CreateNews()
        {
            return View();
        }
        [Authorize(Roles = "TechAdmin,Admin")]
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
        [Authorize(Roles = "TechAdmin,Admin")]
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

        [Authorize(Roles = "TechAdmin,Admin")]
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
        [Authorize(Roles = "TechAdmin,Admin")]
        [HttpPost]
        public ActionResult DeleteNews(string newsId)
        {
            try
            {
                var pathDefaultPhoto = ConfigurationManager.AppSettings["pathDefaultPhoto"];
                var news = NewsService.GetbyId(Convert.ToInt32(newsId));
                if (NewsService.Delete(Convert.ToInt32(newsId)))
                {
                    if(news.HeadImage!=pathDefaultPhoto)
                    {
                        DeletePhotoFromServer(news.HeadImage);
                    }
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
            catch (Exception)
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
        private void DeletePhotoFromServer(string path)
        {
            var location = Server.MapPath($"~{path}");
            System.IO.File.Delete(location);
        }
        [HttpPost]
        public void DeleteNewsHeadPhotoFromServer(string headImage)
        {
            var pathDefaultPhoto = ConfigurationManager.AppSettings["pathDefaultPhoto"];
            if (headImage != "" && headImage != null&&headImage!=pathDefaultPhoto)
            {
                var location = Server.MapPath($"~{headImage}");
                System.IO.File.Delete(location);
            }
        }
    }
}