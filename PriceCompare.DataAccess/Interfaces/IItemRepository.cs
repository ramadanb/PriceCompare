using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Repositories;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Interfaces
{
    public interface IItemRepository: IRepository<Item>
    {

        Item Get(int id);
        Item Get(string itemCode);
        Task<List<Item>> GetAllItemsAsync();
        List<Item> GetAllItemsWithoutDuplicate();
        List<Item> GetExtendedItems(List<Item> selectedItem);
      
    }
}
