using BookManager.Repositories;
using BookManagerModelsLibrary.BookModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookManager.Controllers.BookControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;


        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            var response = await _bookRepository.GetListOfCurrentBestSellers();
            return Ok(response);
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetBookByIsbn(string isbn)
        {
            var response = await _bookRepository.GetBookDetails(isbn);
            return Ok(response);
        }


    }
}
