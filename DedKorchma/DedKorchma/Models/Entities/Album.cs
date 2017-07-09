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
        public DateTime? DateCreated { get; set; }
        public List<AlbumPhoto> Photos { get; set; }

        public Album()
        {
            Photos=new List<AlbumPhoto>();
        }
    }
}