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
        Album GetByURL(string url);
        bool CreateAlbum(Album album);
        bool SavePhotoInAlbum(AlbumPhoto photo);
        bool EditAlbum(Album album);
        bool DeleteAlbum(int albumId);
        List<AlbumPhoto> GetPhotoInAlbum(int albumId);

    }
}
