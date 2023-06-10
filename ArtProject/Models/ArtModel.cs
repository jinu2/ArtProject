
using System.Collections.Generic;
namespace ArtProject.Models
{
    public class ArtModel
    {
        public class Datum
        {
  
            public string api_link { get; set; }
            public int id { get; set; }
            public string title { get; set; }
        }

        public List<Datum> data { get; set; }


    }
 
}
