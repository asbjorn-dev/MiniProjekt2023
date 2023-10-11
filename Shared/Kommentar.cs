using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Kommentar
    {
        public Kommentar() { }

        //kontruktør sætter automatisk dato til nuværende tidspunkt og upvote og downvote
        public Kommentar(string tekst, Bruger bruger)
        {
            Bruger = bruger;
            this.Tekst = tekst;
            Dato = DateTime.Now;
            Upvote = 0;
            Downvote = 0;
        }
        public int KommentarId { get; set; }
        public string Tekst { get; set; }
        public DateTime Dato { get; set; }
        public int? Upvote { get; set; }
        public int? Downvote { get; set; }
        public Bruger Bruger { get; set; }

    }
}
