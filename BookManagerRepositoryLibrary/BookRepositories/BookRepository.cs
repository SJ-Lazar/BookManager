using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerRepositoryLibrary.BookRepositories
{
    public class BookRepository
    {
        public async  Task GetListOfCurrentBestSellers()
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
