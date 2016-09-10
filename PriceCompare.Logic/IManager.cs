using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Entities;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.Logic
{
    public interface IManager
    {
        void InitializeData();
        bool SetShoppingCart(List<Item> allItems);
        List<Item> GetShoppingCartItems();
        Task<List<Item>> GetAllItemsAsync();
        List<Item> GetAllItems();
        List<Tuple<string, string, double>> CompareShoppingCartByChains();
        Dictionary<string, List<Tuple<string, double>>> GetMostThreeExpensiveItems();
        Dictionary<string, List<Tuple<string, double>>> GetCheapestThreeItems();
        Dictionary<string, List<Tuple<string, double>>> CompareShoppingCartByStores();
        bool IsShoppingCartEmpty();
        bool LoadShoppingCartFromFile();
        void SaveShoppingCartToFile();
        User RegisterUser(User user);
        User LoginUser(User user);
        void Logout(User user);
        void ResetShoppingCart();
        bool CreateExcelChartOfChainsCart();


    }
}
