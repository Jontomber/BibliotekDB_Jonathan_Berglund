using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Aurthor
    {
        public int AurthorID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public ICollection<BookAurthor> BookAurthors {get; set;}
    }
}