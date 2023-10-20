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
        /* Havde problemer med at post editform fordi jeg tror muligvis der var nogle null værdier (elsker blazor console errors beskeder) 
                     så nu har jeg givet nogen af værdierne default værdier og det virkede */
        public int TrådeId { get; set; }
        public DateTime Dato { get; set; } = DateTime.Now;
        public string Tråde_Overskrift { get; set; } = "";
        public string Tekst { get; set; } = "";
        public int? Upvote { get; set; } = 0;
        public int? Downvote { get; set; } = 0;
        public List<Kommentar> Kommentare { get; set; } = new List<Kommentar>();
        public Bruger bruger { get; set; } = new Bruger("Default Bruger");
    }
}
