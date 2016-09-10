using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PriceCompare.DataAccess;
using PriceCompare.Entities;
using PriceCompare.Logic.Controllers;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.Logic
{
    public class Manager:IManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private ShoppingCart _shoppingCart;
        private readonly CartCompare _cartCompare;
        private readonly UserController _userController;

        public Manager()
        {
            _unitOfWork = new UnitOfWork(new ChainContext());
            _shoppingCart = new ShoppingCart();
            _cartCompare = new CartCompare(_unitOfWork);
            _userController = new UserController(_unitOfWork);
        }

        public void InitializeData()
        {
             ImportDataFromXml initializeDataFromXml = new ImportDataFromXml(_unitOfWork);
             initializeDataFromXml.Initialize();
   
        }

        public bool SetShoppingCart(List<Item> allItems)
        {
            if (allItems == null)
            {
                throw new ArgumentNullException(nameof(allItems));
            }

            return _shoppingCart.BuildCart(allItems);
        }

        public List<Item> GetShoppingCartItems()
        {
            return _shoppingCart.Items;
        }

        public Task<List<Item>> GetAllItemsAsync()
        {

           return _unitOfWork.Items.GetAllItemsAsync();
          
        }

        public List<Item> GetAllItems()
        {
            return _unitOfWork.Items.GetAllItemsWithoutDuplicate();
            
        }

        public List<Tuple<string, string, double>> CompareShoppingCartByChains()
        {
           
           return _cartCompare.GetCartsTotalPrices(_shoppingCart);

        }
        public Dictionary<string, List<Tuple<string, double>>> GetMostThreeExpensiveItems()
        {

            return _cartCompare.GetExpensiveOrCheapesetItems(true);

        }
        public Dictionary<string, List<Tuple<string, double>>> GetCheapestThreeItems()
        {
            return _cartCompare.GetExpensiveOrCheapesetItems(false);

        }

        public bool IsShoppingCartEmpty()
        {
            return _shoppingCart.IsShoppingCartEmpty;
        }

        public bool LoadShoppingCartFromFile()
        {
            CartSaveAndLoad loadCart = new CartSaveAndLoad();

            try
            {
                _shoppingCart = loadCart.LoadShoppingCartFromFile();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public void SaveShoppingCartToFile()
        {

            CartSaveAndLoad saveCart = new CartSaveAndLoad();

            saveCart.SaveShoppingCartToFile(_shoppingCart);
        }

        public User RegisterUser(User user)
        {
            return _userController.AddNewUser(user);
        }

        public User LoginUser(User user)
        {
            return _userController.LoginUser(user);
        }

        public void Logout(User user)
        {
            _userController.LogoutUpdate(user);
        }

        public void ResetShoppingCart()
        {
            _shoppingCart.Reset();
        }


        public Dictionary<string, List<Tuple<string, double>>> CompareShoppingCartByStores()
        {
            return _cartCompare.GetCartsTotalPricesPerStore(_shoppingCart);
            
        }

        public bool CreateExcelChartOfChainsCart()
        {
            ExcelChart excelChartCreator= new ExcelChart();
            if(_shoppingCart.IsShoppingCartEmpty)
                return false;

           var result= _cartCompare.GetCartsTotalPrices(_shoppingCart);
           
            return excelChartCreator.CreateCompareExcelChart(result);
        }

    
    }
}