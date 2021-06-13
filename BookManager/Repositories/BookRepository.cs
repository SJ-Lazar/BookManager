using BookManagerModelsLibrary.BookModels;
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
        public BookRepository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BookModel> GetListOfCurrentBestSellers()
        {
            BookModel bookModel = new BookModel();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=NwUJgaa7B5baIOBFMDXpXrb1lASXv9y8");

            var client = _httpClient.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                bookModel = await response.Content.ReadFromJsonAsync<BookModel>();
            }

            return bookModel;
        }
    }
}
