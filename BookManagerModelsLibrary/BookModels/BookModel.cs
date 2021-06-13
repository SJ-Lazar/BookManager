using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagerModelsLibrary.BookModels
{

    public class BookModel
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public DateTime last_modified { get; set; }
        public Results results { get; set; }
    }

}
