using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace GBDD
{
    public class DataB
    {

        readonly SQLiteAsyncConnection _database;

        public DataB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DBModel>().Wait();

            _database.CreateTableAsync<AppealModel>().Wait();
        }

        public Task<List<DBModel>> GetNotesAsync()
        {
            return _database.Table<DBModel>().ToListAsync();
        }

        public Task<DBModel> GetNoteAsync(int id)
        {
            return _database.Table<DBModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(DBModel note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(DBModel note)
        {
            return _database.DeleteAsync(note);
        }



        public Task<List<AppealModel>> GetAppealAsync()
        {
            return _database.Table<AppealModel>().ToListAsync();
        }

        public Task<AppealModel> GetAppealAsync(int id)
        {
            return _database.Table<AppealModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppealAsync(AppealModel note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteAppealAsync(AppealModel note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
