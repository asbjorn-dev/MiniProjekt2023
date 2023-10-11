using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Tråde
    {
        public Tråde(Bruger bruger, Kommentar Kommentar)
        {
            this.Bruger = bruger;
            Kommentare = new List<Kommentar>();

        }
        public int Tråde_Id { get; set; }
        public DateTime Dato { get; set; }
        public string Tråde_Overskrift { get; set; }
        public string Tekst { get; set; }
        public int Antal_Stemmer { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public Bruger Bruger { get; set; }
        public List<Kommentar> Kommentare { get; set; }
    }
}
