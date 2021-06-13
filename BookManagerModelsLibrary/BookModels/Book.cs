namespace BookManagerModelsLibrary.BookModels
{
    public class Book
    {
        public int rank { get; set; }
        public int rank_last_week { get; set; }
        public int weeks_on_list { get; set; }
        public int asterisk { get; set; }
        public int dagger { get; set; }
        public string primary_isbn10 { get; set; }
        public string primary_isbn13 { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string contributor { get; set; }
        public string contributor_note { get; set; }
        public string book_image { get; set; }
        public int book_image_width { get; set; }
        public int book_image_height { get; set; }
        public string amazon_product_url { get; set; }
        public string age_group { get; set; }
        public string book_review_link { get; set; }
        public string first_chapter_link { get; set; }
        public string sunday_review_link { get; set; }
        public string article_chapter_link { get; set; }
        public Isbn[] isbns { get; set; }
        public Buy_Links[] buy_links { get; set; }
        public string book_uri { get; set; }
    }

}
