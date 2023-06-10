using System.Drawing;

namespace ArtProject.Models
{
    public class PaintModel
    {
        public class Data
        {
            public int id { get; set; }
            public string api_link { get; set; }
            public string title { get; set; }
            public string artist_display { get; set; }
            public int artist_id { get; set; }
            public string artist_title { get; set; }
            public string style_title { get; set; }
            public string image_id { get; set; }

        }

        public Data data { get; set; }
    }
}
