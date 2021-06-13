namespace BookManagerModelsLibrary.BookModels
{
    public class Review
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public Result[] results { get; set; }
    }

}
