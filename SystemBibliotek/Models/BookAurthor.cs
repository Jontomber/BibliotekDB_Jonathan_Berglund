using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class BookAurthor
    {
        public int AurthorID {get; set;}
        public int BookID {get; set;}
        public int BookAurthorID {get; set;}

        public Aurthor Aurthor {get; set;}
        public Book Book {get; set;}
    }
}