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
        public Category GetById(int categoryId)
        {
            using (var context = new ContextDb())
            {
                return GetById(context, categoryId);
            }
        }

        internal Category GetById(ContextDb context,int categoryid)
        {
            return context.Categories.Find(categoryid);
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
    }
}