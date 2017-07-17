using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DedKorchma.DAL.Interface;
using DedKorchma.DAL.Repository;
using DedKorchma.Models.Entities;

namespace DedKorchma.BL.Service
{
    public static class UserSevice
    {
        public static IList<User> GetAll()
        {
            IUserRepository userRepo=new UserRepository();
            return userRepo.GetAll();
        }
    }
}