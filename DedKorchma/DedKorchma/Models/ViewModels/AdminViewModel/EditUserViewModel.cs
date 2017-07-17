
using System.Collections.Generic;
using System.Web.Mvc;
using DedKorchma.Models.Entities;

namespace DedKorchma.Models.ViewModels.AdminViewModel
{
    public class EditUserViewModel : UserViewModel
    {
        public IList<SelectListItem> RolesList { get; set; }

        public EditUserViewModel(User user) : base(user)
        {
        }

        public EditUserViewModel()
        {

        }
    }
}