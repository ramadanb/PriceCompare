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
    public class PriceRepository:Repository<Price>,IPriceRepository
    {
        public PriceRepository(DbContext context) : base(context)
        {
           
        }

        public Price Get(int itemCode, int storeId)
        {
            return DbSet.Find(itemCode);
        }

        public List<Price> GetPricesOfShoppingCart(List<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            List<Price> prices = new List<Price>();

            foreach (Item item in items)
            {

                prices=prices.Concat(FindBy(priceTable => priceTable.ItemId == item.ItemId).ToList()).ToList();
            }

            return prices;
        }
    }
}
