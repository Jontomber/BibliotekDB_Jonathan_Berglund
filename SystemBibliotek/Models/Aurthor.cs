using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace SystemBibliotek.Models
{
    public class Aurthor
    {
        public int AurthorId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        [Foreignkey (BookID)]
        public int BookID {get; set;}
    }
}