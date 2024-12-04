using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Loan
    {
        public int LoanID {get; set;}
        public int BookID {get; set;}
        public int BorrowerID {get; set;}

        public DateTime BorrowedDate {get; set;}
        public DateTime ReturnDate {get; set;}
        public int Returned{get; set;}
        public string Signature {get; set;}

        public Book Book {get; set;}
    }
}