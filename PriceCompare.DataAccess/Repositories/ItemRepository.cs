using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Interfaces;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public class ItemRepository : Repository<Item>,IItemRepository
    {
        public ItemRepository(DbContext context) : base(context)
        {
        }

        public Item Get(int id)
        {
            return DbSet.Find(id);
        }

        public Item Get(string itemCode)
        {
            return DbSet.Where(item => item.ItemCode == itemCode).First();
        }

        public   Task<List<Item>>  GetAllItemsAsync()
        {
            Task<List<Item>> task =  DbSet.ToListAsync();
          
            return task;

        }

        public List<Item> GetAllItemsWithoutDuplicate()
        {
            List<Item> items = DbSet.ToList().Distinct(new ItemEqualityComparer()).ToList();
            return items;

        }

        public List<Item> GetExtendedItems(List<Item> selectedItem)
        {
            if (selectedItem == null)
            {
                throw new ArgumentNullException(nameof(selectedItem));
            }
            List<Item> listItems = new List<Item>();

            foreach (Item item in selectedItem)
            {
              List<Item> tempList= DbSet.Where(i => i.Name.Equals(item.Name)).ToList();

               listItems =listItems.Concat(tempList).ToList();
            }

            return listItems;

        }

    }
}
