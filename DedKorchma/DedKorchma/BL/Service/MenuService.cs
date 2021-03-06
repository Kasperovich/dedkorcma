﻿using DedKorchma.BL.Infrastructure;
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
    public class MenuService
    {
        public static bool CreteCategory(Category category)
        {
            IMenuRepository menuRepo = new MenuRepository();
            return menuRepo.CreateCategory(category);
        }

        public static bool EditCategory(Category category)
        {
            IMenuRepository menuRepo = new MenuRepository();
            return menuRepo.EditCategory(category);
        }

        public static Category GetCategoryById(int categoryId)
        {
            var pathMenuPhoto = ConfigurationManager.AppSettings["pathMenuPhoto"];
            IMenuRepository menuRepo = new MenuRepository();
            var category = menuRepo.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new NotFoundException("Категория не найдена", "");
            }
            category.HeadImage = pathMenuPhoto + category.HeadImage;
            return category;
        }

        public static Product GetProductById(int productId)
        {
            var pathMenuPhoto = ConfigurationManager.AppSettings["pathMenuPhoto"];
            IMenuRepository menuRepo = new MenuRepository();
            var product = menuRepo.GetProductById(productId);
            if (product == null)
            {
                throw new NotFoundException("Блюдо не найдено", "");
            }
            product.HeadImage = pathMenuPhoto + product.HeadImage;
            return product;
        }

        public static bool CreateProduct(Product product)
        {
            IMenuRepository menuRepo=new MenuRepository();
            return menuRepo.CreateProduct(product);
        }

        public static bool EditProduct(Product product)
        {
            IMenuRepository menuRepo=new MenuRepository();
            return menuRepo.EditProduct(product);
        }

        public static IList<Category> GetAllCategories()
        {
            IMenuRepository menuRepo = new MenuRepository();
            return menuRepo.GetAllCategories();
        }
    }
}