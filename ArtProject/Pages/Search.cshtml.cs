using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using static System.Formats.Asn1.AsnWriter;
using System.Text.RegularExpressions;
using ArtProject.Services;
using ArtProject.Models;
using static ArtProject.Models.PainterPhotoModel;
using static ArtProject.Models.ArtModel;
using System.Reflection;

namespace ArtProject.Pages
{
    public class SearchModel : PageModel
    {

        [BindProperty]
        public string SearchKeyword { get; set; }

        [BindProperty]
        public string painterImage { get; set; }

        [BindProperty]
        public string painterText { get; set; }

        [BindProperty]
        public string artistName { get; set; }

        [BindProperty]
        public List<string> Images { get; set; } = new List<string>();

        [BindProperty]
        public List<string> ImageNames { get; set; } = new List<string>();
        PainterPhotoModel painterPhotoModel { get; set; }
        ArtModel artModel { get; set; }
        PaintModel paintModel { get; set; }

        ArtModel artistModel { get; set; }
        PaintModel painterModel { get; set; }



        public void OnGet()
        {

        }
        public void OnPostSearchRequest(ArtService artService)
        {

            artModel = artService.GetArtModelOneSample(SearchKeyword);
            paintModel = artService.GetPaintModel(artModel.data.FirstOrDefault().api_link);
            var painterName = paintModel.data.artist_title;
            painterName = Regex.Replace(painterName, @"\s", "_");
            painterPhotoModel = artService.GetPainterPhotoModel(painterName);

            painterImage = painterPhotoModel.query.pages.FirstOrDefault().Value.thumbnail.source.ToString();
            painterText = painterPhotoModel.query.pages.FirstOrDefault().Value.extract.ToString();
            artistName = paintModel.data.artist_title.ToString();


            artistModel = artService.GetArtModel(SearchKeyword);
            foreach (var datum in artistModel.data)
            {
                painterModel = artService.GetPaintModel(datum.api_link.ToString());
                var url = "https://www.artic.edu/iiif/2/" + painterModel.data.image_id + "/full/843,/0/default.jpg";
                Images.Add(url);

                ImageNames.Add(painterModel.data.title);

            }

        }

    }
}
