using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
    }
}