using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string NameOfAlbum { get; set; }
        public string HeadImage { get; set; }
        public DateTime? DateCreated { get; set; }

        [Required]
        [MaxLength(100)]
        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        public List<AlbumPhoto> Photos { get; set; }
        public Album()
        {
            Photos=new List<AlbumPhoto>();
        }
    }
}