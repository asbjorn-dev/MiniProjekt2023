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
        public Tråde(Bruger bruger, string tekst, string overskrift)
        {
            this.bruger = bruger;
            Upvote = 0;
            Downvote = 0;
            Dato = DateTime.Now;
            Kommentare = new List<Kommentar>();
            this.Tekst = tekst;
            this.Tråde_Overskrift = overskrift;

        }
        // tom kontruktør
        public Tråde() { }
        public int TrådeId { get; set; }
        public DateTime Dato { get; set; }
        public string Tråde_Overskrift { get; set; }
        public string Tekst { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }
        public List<Kommentar> Kommentare { get; set; } = new List<Kommentar>();
        public Bruger bruger { get; set; }
    }
}
