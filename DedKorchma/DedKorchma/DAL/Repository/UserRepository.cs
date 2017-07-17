using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DedKorchma.DAL.Interface;
using DedKorchma.Models.Entities;

namespace DedKorchma.DAL.Repository
{
    public class UserRepository:IUserRepository
    {
        public IList<User> GetAll()
        {
            using (var context=new ContextDb())
            {
                return GetAll(context);
            }
        }

        internal IList<User> GetAll(ContextDb context)
        {
            return context.Users.ToList();
        }
    }
}