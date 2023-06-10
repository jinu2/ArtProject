using ArtProject.Models;
using System.Net;
using System.Text.Json;

namespace ArtProject.Services
{
    public class ArtService
    {
        public ArtModel GetArtModel(string term)
        {
            string url = "https://api.artic.edu/api/v1/artworks/search?q=" + term + "&limit=12";
            var json = new WebClient().DownloadString(url);
            ArtModel artdata = JsonSerializer.Deserialize<ArtModel>(json);

            return artdata;
        }

        public ArtModel GetArtModelOneSample(string term)
        {
            string url = "https://api.artic.edu/api/v1/artworks/search?q=" + term + "&limit=1";
            var json = new WebClient().DownloadString(url);
            ArtModel artdata = JsonSerializer.Deserialize<ArtModel>(json);

            return artdata;
        }

        public PaintModel GetPaintModel(string term)
        {
            //string url = "https://www.artic.edu/iiif/" + term + "/full/843,/0/default.jpg";
            var json = new WebClient().DownloadString(term);
            PaintModel paintdata = JsonSerializer.Deserialize<PaintModel>(json);

            return paintdata;
        }

        public PainterPhotoModel GetPainterPhotoModel(string term)
        {
            string url = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts|pageimages&exintro&explaintext&redirects=1&titles=" + term + "&pithumbsize=500";
            var json = new WebClient().DownloadString(url);
            PainterPhotoModel painterdata = JsonSerializer.Deserialize<PainterPhotoModel>(json);

            return painterdata;
        }

        public ExhibitionModel GetExhibitionModel()
        {
            string url = string.Concat("https://api.artic.edu/api/v1/exhibitions?limit=20");
            var json = new WebClient().DownloadString(url);
            ExhibitionModel exhdata = JsonSerializer.Deserialize<ExhibitionModel>(json);

            return exhdata;

        }
    }
}