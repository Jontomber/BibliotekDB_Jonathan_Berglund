using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Loan
    {
        public int LoanId {get; set;}
        public string BorrowerDate {get; set;}
        public string ReturnDate {get; set;}

        [Foreignkey (BorrwerID)(BookID)]
        public int BorrowerID {get; set;}
        public int BookID {get; set;}
    }
}