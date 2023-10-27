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
        // henter alle tråde sorteret med dato
        public async Task<IEnumerable<Tråde>> GetTrådesAsync()
        {
            var Trådes = await db.Trådes.Include(b => b.bruger).Include(b => b.Kommentare)
                                          .ThenInclude(t => t.Bruger)
                                          .OrderByDescending(b => b.Dato)
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
        // 2 metoder til upvote downvote Tråde
        public async Task<Tråde> PutUpvoteTrådAsync(int id)
        {
            var UpvoteTråd = db.Trådes.First(b => b.TrådeId == id);
            UpvoteTråd.Upvote++;
            db.SaveChanges();
            return UpvoteTråd;
        }
        public async Task<Tråde> PutDownvoteTrådAsync(int id)
        {
            var DownvoteTråd = db.Trådes.First(b => b.TrådeId == id);
            DownvoteTråd.Downvote++;
            db.SaveChanges();
            return DownvoteTråd;
        }
        // 2 metoder til upvote downvote

        public async Task<Kommentar> PutUpvoteKommentarAsync(int idT, int idK)
        {
            var FindTrådId = db.Trådes.First(b => b.TrådeId == idT);
            var FindKommentarId = db.Kommentar.First(b => b.KommentarId == idK);

            FindKommentarId.Upvote++;
            db.SaveChanges();
            return FindKommentarId;
        }
        public async Task<Kommentar> PutDownvoteKommentarAsync(int idT, int idK)
        {
            var FindTrådId = db.Trådes.First(b => b.TrådeId == idT);
            var FindKommentarId = db.Kommentar.First(b => b.KommentarId == idK);

            FindKommentarId.Downvote++;
            db.SaveChanges();
            return FindKommentarId;
        }
    }
}
