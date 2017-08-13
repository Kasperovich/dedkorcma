using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedKorchma.Models.Entities;

namespace DedKorchma.DAL.Interface
{
    interface IGalleryRepository
    {
        IList<Album> GetAll();
        Album GetById(int id);
        Album GetByName(string url);
        bool CreateAlbum(Album album);
    }
}
