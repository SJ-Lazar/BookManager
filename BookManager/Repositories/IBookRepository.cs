using BookManagerModelsLibrary.BookModels;
using System.Threading.Tasks;

namespace BookManager.Repositories
{
    public interface IBookRepository
    {
        Task<BookModel> GetListOfCurrentBestSellers();
    }
}