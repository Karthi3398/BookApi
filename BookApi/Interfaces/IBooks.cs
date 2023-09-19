using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Interfaces
{
    public interface IBooks
    {
        public IEnumerable<Book> GetBooksWithAuthors();
        public IEnumerable<Book> GetBooksWithAuthorsFromDb();
        public IEnumerable<Book> GetBooksWithPublishersFromDb();
        public decimal GetTotalPrice();
        public bool MoveBookDataToDatabase(List<Book> books);
    }
}
