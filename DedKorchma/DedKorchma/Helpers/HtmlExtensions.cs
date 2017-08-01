using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DedKorchma.Models.ViewModels.Common;

namespace DedKorchma.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Pagination(this HtmlHelper htmlHelper, PaginationViewModel pageInfo,
            Func<int, string> pageUrl)
        {
            if (pageInfo.TotalItems == 0)
            {
                return MvcHtmlString.Empty;
            }
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            TagBuilder li;
            TagBuilder a;

            var originalUrl = pageInfo.Url.Split('/').ToList();
            originalUrl.Add("page");
            var url = $"{string.Join("/", originalUrl)}/";


            a = new TagBuilder("a");
            li = new TagBuilder("li");
            a.MergeAttribute("href", url + $"{1}" + pageInfo.QueryParameters);
            a.MergeAttribute("aria-label", "Previous");
            a.AddCssClass("");
            a.InnerHtml = "<span aria-hidden=\"true\">&laquo;</span>";
            li.InnerHtml += a;
            ul.InnerHtml += li;

            if (pageInfo.TotalPages >= 3 && pageInfo.PageNumber != 1)
            {
                a = new TagBuilder("a");
                li = new TagBuilder("li");
                a.MergeAttribute("href",
                    url + $"{pageInfo.PageNumber - 1}" + pageInfo.QueryParameters);
                a.MergeAttribute("aria-label", "Previous");
                a.AddCssClass("");
                a.InnerHtml = "<span aria-hidden=\"true\"><</span>";
                li.InnerHtml += a;
                ul.InnerHtml += li;
            }

            if (pageInfo.TotalPages >= 5 && pageInfo.PageNumber - 2 >= 1 &&
                pageInfo.PageNumber + 2 < pageInfo.TotalPages)
            {
                for (int i = (int) pageInfo.PageNumber - 2; i <= pageInfo.PageNumber + 2; i++)
                {
                    int page = i;

                    a = new TagBuilder("a");

                    a.MergeAttribute("href", url + $"{i}" + pageInfo.QueryParameters);

                    a.InnerHtml = i.ToString();

                    if (i == pageInfo.PageNumber)
                    {
                        a.AddCssClass("active");
                    }

                    li = new TagBuilder("li");
                    li.InnerHtml += a;
                    ul.InnerHtml += li;
                }
            }

            else
            {
                for (
                    int i = (int) pageInfo.PageNumber == 1
                        ? (int) pageInfo.PageNumber
                        : (int) pageInfo.PageNumber - 1;
                    i <=
                    (pageInfo.PageNumber == pageInfo.TotalPages
                        ? pageInfo.PageNumber
                        : pageInfo.PageNumber + 1);
                    i++)
                {
                    int page = i;

                    a = new TagBuilder("a");

                    a.MergeAttribute("href", url + $"{i}" + pageInfo.QueryParameters);

                    a.InnerHtml = i.ToString();

                    if (i == pageInfo.PageNumber)
                    {
                        a.AddCssClass("active");
                    }

                    li = new TagBuilder("li");
                    li.InnerHtml += a;
                    ul.InnerHtml += li;
                }
            }

            if (pageInfo.TotalPages >= 3 && pageInfo.PageNumber != pageInfo.TotalPages)
            {
                a = new TagBuilder("a");
                li = new TagBuilder("li");
                a.MergeAttribute("href", url + $"{pageInfo.PageNumber + 1}" + pageInfo.QueryParameters);
                a.MergeAttribute("aria-label", "Next");
                a.AddCssClass("");
                a.InnerHtml = "<span aria-hidden=\"true\">></span>";
                li.InnerHtml += a;
                ul.InnerHtml += li;
            }


            a = new TagBuilder("a");
            li = new TagBuilder("li");
            a.MergeAttribute("href", url + $"{pageInfo.TotalPages}" + pageInfo.QueryParameters);
            a.MergeAttribute("aria-label", "Next");
            a.AddCssClass("");
            a.InnerHtml = "<span aria-hidden=\"true\">&raquo;</span>";

            li.InnerHtml += a;
            ul.InnerHtml += li;

            return MvcHtmlString.Create(ul.ToString());
        }
    }
}