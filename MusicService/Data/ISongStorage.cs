using System;

namespace MusicService.Data
{
    public interface IImageStorage
    {
        public string UploadImage(int id, IFormFile file);
    }
}
