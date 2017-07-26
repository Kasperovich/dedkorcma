using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public string HeadImage { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } 


        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string H1 { get; set; }

    }
}