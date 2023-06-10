using System;
namespace ArtProject.Models
{
	public class ExhibitionModel
	{

        public Pagination pagination { get; set; }
        public List<Datum> data { get; set; }
        public Info info { get; set; }
        public Config config { get; set; }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Config
        {
            public string iiif_url { get; set; }
            public string website_url { get; set; }
        }

        public class Contexts
        {
            public List<string> groupings { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public string api_model { get; set; }
            public string api_link { get; set; }
            public string title { get; set; }
            public bool is_featured { get; set; }
            public string short_description { get; set; }
            public string web_url { get; set; }
            public string image_url { get; set; }
            public string status { get; set; }
            public DateTime aic_start_at { get; set; }
            public DateTime aic_end_at { get; set; }
            public int? gallery_id { get; set; }
            public string gallery_title { get; set; }
            public List<int> artwork_ids { get; set; }
            public List<string> artwork_titles { get; set; }
            public List<int> artist_ids { get; set; }
            public List<object> site_ids { get; set; }
            public object image_id { get; set; }
            public List<string> alt_image_ids { get; set; }
            public List<object> document_ids { get; set; }
            public SuggestAutocompleteAll suggest_autocomplete_all { get; set; }
            public DateTime source_updated_at { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class Info
        {
            public string license_text { get; set; }
            public List<string> license_links { get; set; }
            public string version { get; set; }
        }

        public class Pagination
        {
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int total_pages { get; set; }
            public int current_page { get; set; }
            public string next_url { get; set; }
        }


        public class SuggestAutocompleteAll
        {
            public List<string> input { get; set; }
            public Contexts contexts { get; set; }
        }


    }
}

