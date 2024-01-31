using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moodie
{
   public class Database
   {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Humor>();
        }

        public Task<int> InsertDayMoodAsync(Humor dayMood)
        {
            return _database.InsertAsync(dayMood);
        }

        public Task<Humor> GetLastDayMood()
        {
            return _database.Table<Humor>().Where(d => d.Data != DateTime.Now.Date).OrderByDescending(d => d.Data).FirstOrDefaultAsync();
        }

        public Task<Humor> GetDayMood(DateTime dateTime)
        {
            return _database.Table<Humor>().Where(d => d.Data == dateTime).FirstOrDefaultAsync();
        }

        public Task<List<Humor>> GetDayMoods()
        {
            return _database.Table<Humor>().OrderByDescending(d => d.Data).ToListAsync();
        }
   }
}
