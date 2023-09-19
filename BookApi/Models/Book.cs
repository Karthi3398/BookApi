using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Book
    {
        public string Publisher { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public string Title { get; set; }
        public decimal price { get; set; }
        public string ContainerTitle { get; set; }
        public string PublicationDate { get; set; }
        public string location { get; set; }
        public string MLACitationString { get; set; }
        public string Volume { get; set; }
        public string IssueNo { get; set; }
        public string PageRange { get; set; }
        public string Uri { get; set; }
        public string ChicagoStyleCitation { get; set; }

    }
}
