using System.Text.RegularExpressions;
using System.Xml.Linq;
using AngleSharp.Html.Parser;
using ArtProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArtProject.Models;


namespace ArtProject.Pages
{
    public class StreamsModel : PageModel
    {
        [BindProperty]
        public ExhibitionModel exhData { get; set; }

        public void OnGet(ArtService artService)
        {
            exhData = artService.GetExhibitionModel();
            for (int i = 0; i < exhData.pagination.limit; i++)
            {
                var doc = new HtmlParser();
                if (!string.IsNullOrEmpty(exhData.data[i].short_description))
                    exhData.data[i].short_description = Regex.Replace(exhData.data[i].short_description, @"<[^>]*>", String.Empty);
            }
        }
    }
}
