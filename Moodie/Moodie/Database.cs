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

        public Task<int> InsertDayMoodAsync(Humor)
        {
            return _database.InsertAsync(Humor);
        }

        public Task<Humor> GetLastDayMood()
        {
            return _database.Table<Humor>().Where(d => d.Date != DateTime.Now.Date).OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        }

        public Task<Humor> GetDayMood(DateTime dateTime)
        {
            return _database.Table<Humor>().Where(d => d.Date == dateTime).FirstOrDefaultAsync();
        }

        public Task<List<Humor>> GetDayMoods()
        {
            return _database.Table<Humor>().OrderByDescending(d => d.Date).ToListAsync();
        }
   }
}
