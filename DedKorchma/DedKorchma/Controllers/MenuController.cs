using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DedKorchma.Models.ViewModels.MenuViewModel;
using System.Web.Mvc;
using System.IO;
using DedKorchma.BL.Service;

namespace DedKorchma.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CreateCategoryViewModel category)
        {
            if (!ModelState.IsValid) return View();
            if (MenuService.CreteCategory(category.ToEntity()))
            {
                return RedirectToAction("Index", "menu");
            }
            return View();
        }

        public ActionResult EditCategory(int categoryId)
        {
            try
            {
                var category = MenuService.GetbyId(categoryId);
                return View(new EditCategoryViewModel(category));
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult EditController(EditCategoryViewModel category)
        {
            if (!ModelState.IsValid) return View();
            if (MenuService.EditCategory(category.ToEntity()))
            {
                return RedirectToAction("Index", "menu");
            }
            return View();
        }
        public ActionResult SaveCategoryHeadPhoto()
        {
            var pathMenuPhoto = System.Configuration.ConfigurationManager.AppSettings["pathMenuPhoto"];
            var location = Server.MapPath($"~{pathMenuPhoto}");
            string[] filePaths = Directory.GetFiles(location);

            var isSavedSuccessfully = true;
            var fName = "";

            try
            {
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];
                    var filename =
                        $"category-head-photo-{DateTime.Now:yy-MM-dd-HH-mm-ss-fff}-{Guid.NewGuid()}-{file.ContentLength}{Path.GetExtension(file.FileName)}";

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
                    url = System.Configuration.ConfigurationManager.AppSettings["pathMenuPhoto"] + fName
                })
                : Json(new { uploaded = 0, Message = "Ошибка загрузки файла" });
        }
    }
}