using System;
using System.Collections.Generic;
using System.Linq;
using DedKorchma.Models.Entities;
using DedKorchma.Models.ViewModels.NewsViewModel;
using System.Web;

namespace DedKorchma.Models.ViewModels.Common
{
    public class IndexViewModel
    {
        public PaginationViewModel Pagination { get; set; }

        public List<NewsViewModel.NewsViewModel> News { get; set; }

        public IndexViewModel(List<News> news)
        {
            News = news.Select(s => new NewsViewModel.NewsViewModel(s)).ToList();
        }

    }
}