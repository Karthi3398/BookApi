#region Headers
using BookApi.Common;
using BookApi.Interfaces;
using BookApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
#endregion

namespace BookApi.Repositories
{
    /// <summary>
    /// BookRepository
    /// </summary>
    public class BookRepository : IBooks
    {
        #region Public Methods
        /// <summary>
        /// GetBooksWithAuthors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksWithAuthors()
        {
            List<Book> books = new List<Book>();
            Book book = new Book();
            book.Title = "The 5AM CLUB";
            book.AuthorFirstName = "Robin";
            book.AuthorLastName = "Sharma";
            book.price = 250;
            book.Publisher = "Jaico Publications";
            book.ContainerTitle = "On Writing,Editing,Publishing";
            book.PublicationDate =  new DateTime(1998, 03, 03).ToShortDateString();
            book.location = "pp. 1-236";
            book.Volume = "Vol 1";
            book.IssueNo = "March 2004";
            book.PageRange = "1-190";
            book.Uri = "https://google.com";
            book.MLACitationString = book.AuthorLastName+","+book.AuthorFirstName+"." + $@"""{book.Title}""" + " "+book.ContainerTitle+
                ","+book.Publisher+","+book.PublicationDate+","+book.location;
            book.ChicagoStyleCitation = book.AuthorLastName+","+book.AuthorFirstName+"."+book.PublicationDate+ "." + $@"""{book.Title}""" +
                ","+book.Volume+", ("+book.IssueNo+"):"+book.PageRange+"."+book.Uri;
            books.Add(book);

            book = new Book();
            book.Title = "Immortals of Meluha";
            book.AuthorFirstName = "Amish";
            book.AuthorLastName = "Tripati";
            book.price = 300;
            book.Publisher = "Westland Publications";
            book.ContainerTitle = "On Writing,Editing,Publishing";
            book.PublicationDate = new DateTime(2010, 08, 03).ToShortDateString();
            book.location = "pp. 1-126";
            book.Volume = "Vol 2";
            book.IssueNo = "August 2010";
            book.PageRange = "1-390";
            book.Uri = "https://google.com";
            book.MLACitationString = book.AuthorLastName + "," + book.AuthorFirstName + "." + $@"""{book.Title}""" + " " + book.ContainerTitle +
               "," + book.Publisher + "," + book.PublicationDate + "," + book.location;
            book.ChicagoStyleCitation = book.AuthorLastName + "," + book.AuthorFirstName + "." + book.PublicationDate + "." + $@"""{book.Title}""" +
                "," + book.Volume + ", (" + book.IssueNo + "):" + book.PageRange + "." + book.Uri;
            books.Add(book);

            book = new Book();
            book.Title = "Rich Dad Poor Dad";
            book.AuthorFirstName = "Robert";
            book.AuthorLastName = "Kiyosaki";
            book.price = 350;
            book.Publisher = "Penguin Random House India PVT LTD";
            book.ContainerTitle = "On Writing,Editing,Publishing";
            book.PublicationDate = new DateTime(2019, 04, 04).ToShortDateString();
            book.location = "pp. 1-126";
            book.Volume = "Vol 2";
            book.IssueNo = "April 2019";
            book.PageRange = "1-543";
            book.MLACitationString = book.AuthorLastName + "," + book.AuthorFirstName + "." + $@"""{book.Title}""" + " " + book.ContainerTitle +
               "," + book.Publisher + "," + book.PublicationDate + "," + book.location;
            book.ChicagoStyleCitation = book.AuthorLastName + "," + book.AuthorFirstName + "." + book.PublicationDate + $@"""{book.Title}""" +
                "," + book.Volume + ", (" + book.IssueNo + "):" + book.PageRange + "." + book.Uri;
            book.Uri = "https://google.com";
            books.Add(book);
            return books;
        }

        /// <summary>
        /// GetBooksWithAuthorsFromDb
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksWithAuthorsFromDb()
        {
            List<Book> books = new List<Book>();
            using(SqlConnection sqlConnection = new SqlConnection(Constants.SQLConnectionString))
            {
             books  = sqlConnection.Query<Book>(
         "sp_getbooksbyauthor",
         commandType: CommandType.StoredProcedure
     ).ToList();
            }

            return books;
        }

        /// <summary>
        /// GetBooksWithPublishersFromDb
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksWithPublishersFromDb()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.SQLConnectionString))
            {
                books = sqlConnection.Query<Book>(
            "sp_getbooksbypublisher",
            commandType: CommandType.StoredProcedure
        ).ToList();
            }
            return books;
        }

        /// <summary>
        /// GetTotalPrice
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPrice()
        {
            decimal price = 0;
            string query = "SELECT SUM(price) from books";
            using (SqlConnection sqlConnection = new SqlConnection(Constants.SQLConnectionString))
            {
                price = sqlConnection.ExecuteScalar<decimal>(query);
            }

            return price;
        }

        /// <summary>
        /// MoveBookDataToDatabase
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public bool MoveBookDataToDatabase(List<Book> books)
        {
            
            string query = "INSERT INTO books(Publisher,AuthorLastName,AuthorFirstName,Price,Title)Values(@Publisher,@AuthorLastName,@AuthorFirstName,@Price,@Title)";
            using (SqlConnection sqlConnection = new SqlConnection(""))
            {
                sqlConnection.Execute(query,books);
            }
            return true;
        }
        #endregion
    }
}
