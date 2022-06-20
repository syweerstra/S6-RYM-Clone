using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.Data
{
    public class AzureBlobStorage : IImageStorage
    {
        //todo: should of course come from somewhere else
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=s6rymclonestorage;AccountKey=d3+35r2s0mx/rGF5XC6WDOk1FcWNXsuN+qdLQpuBXw2YcRQwQfD1n3W5ZDilcL0X4sqVC7kbd/C0um3bIO0dxg==;EndpointSuffix=core.windows.net";
        private readonly string containerName = "images";

        public string UploadImage(int id, IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName); 
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            BlobClient blob = container.GetBlobClient($"albumCoverImageID{id}{extension}");
            using Stream f = file.OpenReadStream();
            blob.Upload(f, new BlobHttpHeaders{ ContentType = file.ContentType}, conditions: null);

            var uri = blob.Uri.AbsoluteUri;
            return uri;
        }
    }
}
