using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DedKorchma.Models.Entities;

namespace DedKorchma.DAL.Interface
{
    public interface IUserRepository
    {
        IList<User> GetAll();
    }
}