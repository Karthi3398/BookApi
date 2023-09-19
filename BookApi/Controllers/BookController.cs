#region Headers
using BookApi.Interfaces;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        #region Declarations
        private IBooks _books;
        #endregion

        #region Constructor
        public BookController(IBooks books)
        {
            _books = books;
        }
        #endregion

        #region Action Methods
        /// <summary>
        /// GetBooksWithPublisherSort
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetBooksWithPublisherSort))]
        public IEnumerable<Book> GetBooksWithPublisherSort()
        {
            var list = _books.GetBooksWithAuthors();
            list =  list.OrderBy(x => x.Publisher).ThenBy(x=>x.AuthorLastName).ThenBy(x=>x.AuthorFirstName).ThenBy(x=>x.Title);
            return list;

        }

        /// <summary>
        /// GetBooksWithPublisherSortFromDB
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetBooksWithPublisherSortFromDB))]
        public IEnumerable<Book> GetBooksWithPublisherSortFromDB()
        {
            var list = _books.GetBooksWithPublishersFromDb();
            return list;

        }

        /// <summary>
        /// GetBooksWithAuthorSort
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetBooksWithAuthorSort))]
        public IEnumerable<Book> GetBooksWithAuthorSort()
        {
            var list = _books.GetBooksWithAuthors();
            list =  list.OrderBy(x=>x.AuthorLastName).ThenBy(x=>x.AuthorFirstName).ThenBy(x=>x.Title);
            return list;

        }

        /// <summary>
        /// GetBooksWithAuthorSortFromDB
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetBooksWithAuthorSortFromDB))]
        public IEnumerable<Book> GetBooksWithAuthorSortFromDB()
        {
            var list = _books.GetBooksWithAuthorsFromDb();

            return list;

        }

        /// <summary>
        /// GetTotalPrice
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTotalPrice))]
        public decimal GetTotalPrice()
        {
            return _books.GetTotalPrice();
        }

        /// <summary>
        /// MoveBookDataToDatabase
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        [HttpPost(nameof(MoveBookDataToDatabase))]
        public bool MoveBookDataToDatabase(List<Book>books)
        {
            return _books.MoveBookDataToDatabase(books);
        }
        #endregion
    }
}
