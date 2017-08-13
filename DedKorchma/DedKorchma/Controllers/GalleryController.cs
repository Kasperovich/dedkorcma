﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DedKorchma.BL.Service;
using DedKorchma.Models.ViewModels.GalleryViewModel;
using System.IO;
using System.Drawing;
using ImageProcessor;

namespace DedKorchma.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Index()
        {
            var gallery = GalleryService.GetAll().ToList();
            return View(new GalleryViewModel(gallery));
        }

        [HttpGet]
        [Authorize(Roles = "TechAdmin,Admin")]
        public ActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "TechAdmin,Admin")]
        public ActionResult CreateAlbum(CreateAlbumViewModel album)
        {
            if (!ModelState.IsValid) return View();
            if (GalleryService.CreateAlbum(album.ToEntity()))
            {
                return RedirectToAction("Index","Gallery");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detailsalbum(string url)
        {
            try
            {
                var album = GalleryService.GetByName(url);
                return View(new DetailsAlbumViewModel(album));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult SaveGalleryPhoto()
        {
            var pathGalleryPhoto = System.Configuration.ConfigurationManager.AppSettings["pathGalleryPhoto"];
            var location = Server.MapPath($"~{pathGalleryPhoto}");
            string[] filePaths = Directory.GetFiles(location);

            var isSavedSuccessfully = true;
            var fName = "";

            try
            {
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];
                    var filename =
                        $"teacher-photo-{DateTime.Now:yy-MM-dd-HH-mm-ss-fff}-{Guid.NewGuid()}-{file.ContentLength}{Path.GetExtension(file.FileName)}";

                    fName = filename;

                    filename = Path.Combine(location, filename);

                    bool isExists = Directory.Exists(location);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(location);

                    file.SaveAs(filename);

                    byte[] photoBytes = System.IO.File.ReadAllBytes(filename);
                    using (var inStream = new MemoryStream(photoBytes))
                    using (var imageFactory = new ImageFactory(false))
                    {
                        var img = imageFactory.Load(inStream);
                        img.Resize(new Size(0, 1080));
                        img.Quality(70);
                        img.Save(filename);
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;

            }


            return isSavedSuccessfully
                ? Json(new
                {
                    Message = "Successful",
                    name = System.Configuration.ConfigurationManager.AppSettings["pathTeachersPhoto"] + fName
                })
                : Json(new { Message = "Error in saving file" });
        }
        public ActionResult SaveGalleryHeadPhoto()
        {
            var pathGalleryPhoto = System.Configuration.ConfigurationManager.AppSettings["pathGalleryPhoto"];
            var location = Server.MapPath($"~{pathGalleryPhoto}");
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
                    url = System.Configuration.ConfigurationManager.AppSettings["pathGalleryPhoto"] + fName
                })
                : Json(new { uploaded = 0, Message = "Ошибка загрузки файла" });
        }
        private void DeletePhotoFromServer(string path)
        {
            var location = Server.MapPath($"~{path}");
            System.IO.File.Delete(location);
        }
    }
}