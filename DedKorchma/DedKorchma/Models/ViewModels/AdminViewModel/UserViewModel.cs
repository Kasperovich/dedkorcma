using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.AdminViewModel
{
    public class UserViewModel
    {
        [Display(Name="Id")]
        public string Id { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name="Роли")]
        public List<string> Roles { get; set; }
        [Display(Name = "Заблокирован")]
        public bool isDeleted { get; set; }

        public UserViewModel(User user, List<string> roles)
        {
            Id = user.Id;
            Email = user.Email;
            Roles = roles;
            isDeleted = user.IsDeleted;
        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            isDeleted = user.IsDeleted;
        }

        public UserViewModel()
        {
            
        }
    }
}