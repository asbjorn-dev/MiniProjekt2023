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
        public Tråde(string tekst, string overskrift)
        {
            Antal_Stemmer = 0;
            Upvote = 0;
            Downvote = 0;
            Dato = DateTime.Now;
            Kommentare = new List<Kommentar>();
            this.Tekst = tekst;
            this.Tråde_Overskrift = overskrift;

        }
        public int Tråde_Id { get; set; }
        public DateTime Dato { get; set; }
        public string Tråde_Overskrift { get; set; }
        public string Tekst { get; set; }
        public int? Antal_Stemmer { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }
        public List<Kommentar> Kommentare { get; set; }
    }
}
