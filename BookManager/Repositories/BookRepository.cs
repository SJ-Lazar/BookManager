using BookManagerModelsLibrary.BookModels;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookManager.Repositories
{
    public class BookRepository : IBookRepository
    {
        //Private Variables
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookRepository> _log;

        //Constructor
        public BookRepository(IHttpClientFactory httpClient,
                              ILogger<BookRepository> log)
        {
            _httpClient = httpClient;
            _log = log;
        }


        //Methods
        /// <summary>
        /// Gets A List of Best Sellers Books.
        /// </summary>
        /// <returns>A BookModel</returns>
        public async Task<BookModel> GetListOfCurrentBestSellers()
        {
            BookModel bookModel = new BookModel();
            try
            {
                var client = _httpClient.CreateClient("meta");
                bookModel = await client.GetFromJsonAsync<BookModel>($"lists/current/hardcover-fiction.json?api-key=NwUJgaa7B5baIOBFMDXpXrb1lASXv9y8");          
            }
            catch (Exception ex)
            {
                bookModel.status = $"Error occured when retrieving list of book: {ex.Message}";
                _log.LogError($"{ex.Message}");
            }
            return bookModel;
        }


        /// <summary>
        /// Gets Details of the book.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>Review</returns>
        public async Task<Review> GetBookDetails(string isbn)
        {
            Review review = new Review();
            try
            {             
                var client = _httpClient.CreateClient("meta");
                review = await client.GetFromJsonAsync<Review>($"reviews.json?isbn={isbn}&api-key=NwUJgaa7B5baIOBFMDXpXrb1lASXv9y8");
            }
            catch (Exception ex)
            {
                review.status = $"Error occured when getting book review: {ex.Message}";
                _log.LogError($"{ex.Message}");
            }
            return review;
        }
    }
}
