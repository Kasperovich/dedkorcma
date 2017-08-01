using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.ViewModels.Common
{
    public class PaginationViewModel
    {
        public int PageNumber { get; set; } = 1; // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов

        public int TotalPages // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }

        public string Url { get; set; }
        public string QueryParameters { get; set; }

    }
}