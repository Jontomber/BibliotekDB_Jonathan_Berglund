using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Book
    {
        public int BookID {get; set;}
        public string Title {get; set;}
        
        public DateOnly PublishDate {get; set;}
        public bool ReadyLoan {get; set;}

        public ICollection<BookAurthor> BookAurthors {get;set;}
        public ICollection<Loan> Loans {get; set;}
    }
}