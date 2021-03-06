using BookManagerModelsLibrary.BookModels;
using System.Threading.Tasks;

namespace BookManager.Repositories
{
    public interface IBookRepository
    {
      
        Task<Review> GetBookDetails(string isbn);
        Task<BookModel> GetListOfCurrentBestSellers();
    }
}