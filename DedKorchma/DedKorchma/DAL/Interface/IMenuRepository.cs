using DedKorchma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.DAL.Interface
{
    interface IMenuRepository
    {
        bool CreateCategory(Category category);
        bool EditCategory(Category category);
        Category GetById(int categoryId);
    }
}