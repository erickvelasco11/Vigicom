using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Vigicom.Models;

using Xamarin.Essentials;

namespace Vigicom.Services
{
    public class AccountService
    {
        private static AccountService instance;

        public static AccountService Instance => instance ??= new AccountService();

        private SQLiteAsyncConnection db;

        public async Task Init()
        {
            if (db != null)
            {
                return;
            }

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Vigicom.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Account>();
        }

        public async Task<Account> AddAccount(Account account)
        {
            await Init();
            account.Id = Guid.NewGuid();
            return await db.InsertAsync(account) > 0 ? account : null;
        }

        public async Task<Account> GetAccount(Guid id)
        {
            await Init();
            return await db.GetAsync<Account>(id);
        }

        public async Task<bool> DeleteAccount(Guid id)
        {
            await Init();
            return await db.DeleteAsync<Account>(id) > 0;
        }

        public async Task<bool> EditAccount(Account account)
        {
            await Init();
            return await db.UpdateAsync(account) > 0;
        }
    }
}
