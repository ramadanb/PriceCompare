using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Repositories;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Price Get(int itemCode, int storeId);
        List<Price> GetPricesOfShoppingCart(List<Item> items);
    }
}
