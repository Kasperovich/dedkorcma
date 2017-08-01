using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.BL
{
    public class PaginationParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int TotalCount { get; set; }
    }
}