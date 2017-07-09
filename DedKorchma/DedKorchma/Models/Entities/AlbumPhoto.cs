using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DedKorchma.Models.Entities
{
    public class AlbumPhoto
    {
        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}