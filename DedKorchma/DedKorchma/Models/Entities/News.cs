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
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
    }
}