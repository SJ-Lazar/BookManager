using BookManagerModelsLibrary.BookModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookManager.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookRepository> _log;
        public BookRepository(IHttpClientFactory httpClient,
                              ILogger<BookRepository> log)
        {
            _httpClient = httpClient;
            _log = log;
        }

        /// <summary>
        /// Gets A List of Best Sellers Books
        /// </summary>
        /// <returns>A BookModel</returns>
        public async Task<BookModel> GetListOfCurrentBestSellers()
        {
            BookModel bookModel = new BookModel();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                      "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=NwUJgaa7B5baIOBFMDXpXrb1lASXv9y8");

                var client = _httpClient.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    bookModel = await response.Content.ReadFromJsonAsync<BookModel>();
                }
                else
                {
                    bookModel.status = $"Error occured when getting list of best sellers: {response.ReasonPhrase}";
                }
               
            }
            catch (Exception ex)
            {
                _log.LogError($"{ex.Message}");
            }
            return bookModel;
        }

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
                review.status = $"Error occured when getting Book: {ex.Message}";
                _log.LogError($"{ex.Message}");
            }
            return review;
        }
    }
}
