using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnacleAssignment.models;
using SQLite;

namespace AnacleAssignment.datasource
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;
        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }
        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }
    }
}
