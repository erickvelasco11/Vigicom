using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace Vigicom.Services
{
    public class DbService
    {
        private static DbService instance;

        public static DbService Instance => instance ??= new DbService();

        private SQLiteAsyncConnection db;

        public async Task Init<T>() where T : new()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Vigicom.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<T>();
        }

        public async Task<List<T>> GetAll<T>() where T : new()
        {
            await Init<T>();
            return await db.Table<T>().ToListAsync();
        }

        public async Task<T> Add<T>(T register) where T : new()
        {
            await Init<T>();
            return await db.InsertAsync(register) > 0 ? register : default;
        }

        public async Task<T> Single<T>(Guid id) where T : new()
        {
            await Init<T>();
            return await db.GetAsync<T>(id);
        }

        public async Task<List<T>> Find<T>(Expression<Func<T, bool>> where) where T : new()
        {
            try
            {
                await Init<T>();
                return await db.Table<T>().Where(where).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete<T>(Guid id) where T : new()
        {
            await Init<T>();
            return await db.DeleteAsync<T>(id) > 0;
        }

        public async Task<bool> Delete<T>(T register) where T : new()
        {
            await Init<T>();
            return await db.DeleteAsync(register) > 0;
        }

        public async Task<bool> Delete<T>(Expression<Func<T, bool>> where) where T : new()
        {
            await Init<T>();
            return await db.Table<T>().DeleteAsync(where) > 0;
        }

        public async Task<bool> Edit<T>(T register) where T : new()
        {
            await Init<T>();
            return await db.UpdateAsync(register) > 0;
        }

        public async Task<int> Count<T>() where T : new()
        {
            await Init<T>();
            return await db.Table<T>().CountAsync();
        }
    }
}
