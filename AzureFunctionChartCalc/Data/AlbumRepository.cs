using AzureFunctionChartCalc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionChartCalc.Data
{
    public class AlbumRepository
    {
        private readonly SqlContext context;

        public AlbumRepository(SqlContext context)
        {
            this.context = context;
        }

        public List<Album> GetAllAlbums()
        {
            return context.Albums.Include("Artist").Include("Ratings").ToList();
        }

        public void UpdateAlbum(List<Album> albums)
        {
            context.Albums.UpdateRange(albums);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
