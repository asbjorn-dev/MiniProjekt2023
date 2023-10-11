using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using Shared;

namespace Service
{
    public class DataService
    {
        private TrådeContext db { get; }

        public DataService(TrådeContext DB)
        {
            this.db = DB;
        }

        public async Task<IEnumerable<Tråde>> GetBoardsAsync()
        {
            var Trådes = await db.Trådes.Include(b => b.Kommentare)
                                          .ThenInclude(t => t.Bruger)
                                          .ToListAsync();
            return Trådes;
        }



    }
}
