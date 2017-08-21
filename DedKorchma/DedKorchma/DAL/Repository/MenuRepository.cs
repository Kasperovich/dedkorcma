using DedKorchma.DAL.Interface;
using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DedKorchma.DAL.Repository
{
    public class MenuRepository:IMenuRepository
    {
        public Category GetCategoryById(int categoryId)
        {
            using (var context = new ContextDb())
            {
                return GetCategoryById(context, categoryId);
            }
        }

        internal Category GetCategoryById(ContextDb context,int categoryid)
        {
            return context.Categories.Find(categoryid);
        }

        public Product GetProductById(int productId)
        {
            using (var context=new ContextDb())
            {
                return GetProductById(context, productId);
            }
        }

        internal Product GetProductById(ContextDb context, int productId)
        {
            return context.Products.Find(productId);
        }

        public bool CreateCategory(Category category)
        {
            using(var context=new ContextDb())
            {
                return CreateCategory(context,category);
            }
        }
        
        internal bool CreateCategory(ContextDb context, Category category)
        {
            context.Categories.Add(category);
            return context.SaveChanges() == 1;
        }

        public bool EditCategory(Category category)
        {
            using(var context =new ContextDb())
            {
                return EditCategory(context,category);
            }
        }

        internal bool EditCategory(ContextDb context,Category category)
        {
            DbEntityEntry<Category> entry = context.Entry(category);
            entry.State = EntityState.Modified;
            return context.SaveChanges() == 1;
        }

        public bool CreateProduct(Product product)
        {
            using (var context=new ContextDb())
            {
                return CreateProduct(context, product);
            }
        }

        internal bool CreateProduct(ContextDb context, Product product)
        {
            context.Products.Add(product);
            return context.SaveChanges() == 1;
        }

        public bool EditProduct(Product product)
        {
            using (var context=new ContextDb())
            {
                return EditProduct(context, product);
            }
        }

        internal bool EditProduct(ContextDb context, Product product)
        {
            DbEntityEntry<Product> entry = context.Entry(product);
            entry.State = EntityState.Modified;
            return context.SaveChanges() == 1;
        }
    }
}