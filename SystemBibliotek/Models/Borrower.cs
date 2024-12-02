using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Borrower
    {
        public int BorrowerID {get; set;}
        public string FullName {get; set;}
        public string ContactDetails {get; set;}
    }
}