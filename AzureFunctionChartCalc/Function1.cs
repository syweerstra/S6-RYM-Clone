using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctionChartCalc.Data;
using System.Collections.Generic;
using AzureFunctionChartCalc.Models;
using System.Linq;

namespace AzureFunctionChartCalc
{
    public class Functions
    {
        private readonly AlbumRepository albumRepo;

        public Functions(AlbumRepository repo)
        {
            albumRepo = repo;
        }
        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("CalculateChartPositions")]
        public async Task<IActionResult> CalculateChartPositions(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            List<Album> albums = albumRepo.GetAllAlbums();
            List<ChartCalcAlbum> albumsWithWeightedRatings = new();

            foreach (var album in albums)
            {
                if (album.AmountOfRatings > 0)
                {
                    double weightedRating = album.Ratings.Sum(rating => rating.RatingOutOfTen) * (album.AmountOfRatings * 0.5);
                    albumsWithWeightedRatings.Add(new ChartCalcAlbum(album, weightedRating));
                }
            }
            albumsWithWeightedRatings.OrderByDescending(x => x.WeightedRating).ToList();

            for (int i = 0; i < albumsWithWeightedRatings.Count; i++)
            {
                int albumId = albumsWithWeightedRatings[i].Album.ID;
                albums.Find(x => x.ID == albumId).PositionInChart = i + 1; // +1 to account for index starting at  0
            }

            albumRepo.UpdateAlbum(albums);
            albumRepo.Save();
            
            return new OkObjectResult("The album positions have successfully been calculated and changed");
        }

        [FunctionName("CalculateChartPositionsTimeTrigger")]
        public async Task<IActionResult> CalculateChartPositionsTimeTrigger(
         [TimerTrigger("0 0 10 * * Mon")] TimerInfo myTimer,
         ILogger log)
        {
            List<Album> albums = albumRepo.GetAllAlbums();
            List<ChartCalcAlbum> albumsWithWeightedRatings = new();

            foreach (var album in albums)
            {
                if (album.AmountOfRatings > 0)
                {
                    double weightedRating = album.Ratings.Sum(rating => rating.RatingOutOfTen) * (album.AmountOfRatings * 0.5);
                    albumsWithWeightedRatings.Add(new ChartCalcAlbum(album, weightedRating));
                }
            }
            albumsWithWeightedRatings.OrderByDescending(x => x.WeightedRating).ToList();

            for (int i = 0; i < albumsWithWeightedRatings.Count; i++)
            {
                int albumId = albumsWithWeightedRatings[i].Album.ID;
                albums.Find(x => x.ID == albumId).PositionInChart = i + 1; // +1 to account for index starting at  0
            }

            albumRepo.UpdateAlbum(albums);
            albumRepo.Save();

            return new OkObjectResult("The album positions have successfully been calculated and changed");
        }
    }
}
