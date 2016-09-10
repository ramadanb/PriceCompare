using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.Logic
{
    [Serializable]
    public class ShoppingCart
    {
        public List<Item> Items { get; set; }

        public bool IsShoppingCartEmpty => Items.Any(t => t.Amount == 0) || Items.Count==0;

        public ShoppingCart()
        {
            Items = new List<Item>();
        }

        public bool BuildCart(List<Item> allItems)
        {
            List<Item> selectedItems = allItems.Where(i => i.Amount != 0).ToList();

            if (selectedItems.Count == 0)
            {
             
                return false;
            }

            Items = selectedItems;
           
            return true;
        }

        public void Reset()
        {
            Items.Clear();
        }
    }
}
