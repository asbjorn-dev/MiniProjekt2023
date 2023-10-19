using Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Service
{
    public class DataService
    {
        public TrådeContext db { get; }

        public DataService(TrådeContext DB)
        {
            this.db = DB;
        }
        // henter alle tråde
        public async Task<IEnumerable<Tråde>> GetTrådesAsync()
        {
            var Trådes = await db.Trådes.Include(b => b.bruger).Include(b => b.Kommentare)
                                          .ThenInclude(t => t.Bruger)
                                          .ToListAsync();
            return Trådes;
        }
        // Post en tråd metode
        public async Task<Tråde> PostTrådesAsync(Tråde tråd)
        {
            db.Trådes.Add(tråd);
            db.SaveChanges();
            return tråd;
        }
        // Post en kommentar til en bestemt tråd id hvor den matcher id'et fra URL med id'et fra tråden
        public async Task<Kommentar> PostKommentarAsync(Kommentar kommentar, int id)
        {
            var tråd = db.Trådes.First(b => b.TrådeId == id);
            tråd.Kommentare.Add(kommentar);
            db.SaveChanges();
            return kommentar;
        }
        // Mangler like/dislike på clientside
    }
}
