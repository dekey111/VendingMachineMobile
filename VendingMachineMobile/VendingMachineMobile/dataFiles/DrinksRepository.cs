using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace VendingMachineMobile.dataFiles
{
    public class DrinksRepository
    {
        SQLiteAsyncConnection database;

        public DrinksRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Drinks>();
        }
        public async Task<List<Drinks>> GetItemsAsync()
        {
            return await database.Table<Drinks>().ToListAsync();

        }
        public async Task<Drinks> GetItemAsync(int id)
        {
            return await database.GetAsync<Drinks>(id);
        }
        public async Task<int> DeleteItemAsync(Drinks item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Drinks item)
        {
            if (item.IdDrinks != 0)
            {
                await database.UpdateAsync(item);
                return item.IdDrinks;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

    }
}
