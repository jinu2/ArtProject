namespace ArtProject.Models
{
    public class PainterPhotoModel
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }

        public class Query
        {
            public List<Normalized> normalized { get; set; }
            public Dictionary<string, Page> pages { get; set; }
        }

        public class Normalized
        {
            public string from { get; set; }
            public string to { get; set; }
        }

        public class Page
        {
            public string extract { get; set; }
            public Thumbnail thumbnail { get; set; }
        }

        public class Thumbnail
        {
            public string source { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

    }
}
