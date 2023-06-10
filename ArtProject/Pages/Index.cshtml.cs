using ArtProject.Models;
using ArtProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AngleSharp.Html.Parser;
using System.Text.RegularExpressions;

namespace ArtProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        ArtModel artModel { get; set; }

        PaintModel paintModel { get; set; }

        [BindProperty]
        public ExhibitionModel exhData { get; set; }

        List<string> artists = new List<string> {
            "van_gogh", "el_greco", "edgar_degas", "caravaggio", "claude_monet",
            "paul_gaugin", "salvador_dali", "rembrant", "michelangelo", "piet_mondrian",
            "titian", "jackson_pollock"
            };

        [BindProperty]
        public List<PaintModel> Paints { get; set; }

        [BindProperty]
        public List<string> Images { get; set; }
        public void OnGet(ArtService artService)
        {
            Paints = new List<PaintModel>();
            Images = new List<string>();
            foreach (var artist in artists)
            {
                artModel = artService.GetArtModelOneSample(artist);
                if (artModel != null && artModel.data != null)
                {
                    foreach (var datum in artModel.data)
                    {
                        paintModel = artService.GetPaintModel(datum.api_link);
                        Paints.Add(paintModel);
                    }
                }
            }
            for (int i = 0; i < artists.Count; i++)
            {
                var url = "https://www.artic.edu/iiif/2/" + Paints[i].data.image_id + "/full/843,/0/default.jpg";
                Images.Add(url);
            }

            exhData = artService.GetExhibitionModel();
            for (int i = 0; i < exhData.pagination.limit; i++)
            {
                var doc = new HtmlParser();
                if (!string.IsNullOrEmpty(exhData.data[i].short_description))
                    exhData.data[i].short_description = Regex.Replace(exhData.data[i].short_description, @"<[^>]*>", String.Empty);
            }

        }

        public void OnPost()
        {

        }


    }
}