using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PriceCompare.DataAccess;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.Logic
{
    public class CartCompare
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<Item>  _itemsList;
        private List<Price> _pricesList;
        private List<Store> _storesList;
        private List<Chain> _chainsList;

        public CartCompare(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
        }

        public List<Tuple<string,string,double>> GetCartsTotalPrices(ShoppingCart shoppingCart)
        {
            List<Tuple<string, string, double>> compareResult  = new List<Tuple<string, string, double>>();

            _itemsList= GetExtendedItems(shoppingCart.Items);
            _pricesList = _unitOfWork.Prices.GetPricesOfShoppingCart(_itemsList);
            _storesList = _unitOfWork.Stores.GetStores(_pricesList);
            _chainsList = _unitOfWork.Chains.GetChains(_storesList);

            var queryTotalPriceForStores = (from price in _pricesList
                         group price by price.StoreId into priceGroup
                         
                         let sum = (from store in priceGroup
                                     let price =store.PriceItem
                                    select price*_itemsList.Find(i=>i.ItemId==store.ItemId).Amount).Sum()
                         select new
                         {
                             StoreId= priceGroup.Key ,
                             Sum =sum
                            
                         }
                         ).ToList();


            var queryTotalPriceForChains = (from store in _storesList
                join storePrice in queryTotalPriceForStores
                    on store.StoreId equals storePrice.StoreId
                 join chain in _chainsList
                    on store.ChainId equals chain.ChainId

                select new
                {
                    ChainId = chain.ChainId,
                    ChainName=chain.Name,
                    StoreName = store.Name,
                    StoreId = store.StoreId,
                    Sum = storePrice.Sum
                }).Distinct();


            var queryChainGrouped = (from chainData in queryTotalPriceForChains
                group chainData by chainData.ChainId
                into chainGroup
             
                select chainGroup.OrderBy(obj => obj.Sum).First()).ToList();

            queryChainGrouped.Sort((obj1, obj2) => obj1.Sum.CompareTo(obj2.Sum));
            
            foreach (var chain in queryChainGrouped)
            {
                compareResult.Add(new Tuple<string, string, double>(
                    chain.ChainName,
                    chain.StoreName,
                    chain.Sum

                    ));
            }

            return compareResult ;

        }

        /// <summary>
        /// flagMostExpensive = true to get a list of the mose three expensive items
        /// or flagMostExpensive = false to get the cheapest three items
        /// </summary>
        /// <param name="flagMostExpensive"></param>
        /// <returns>List of tuples(ChainName ItemName Price)</returns>

        public Dictionary<string, List<Tuple<string, double>>> GetExpensiveOrCheapesetItems(bool flagMostExpensive)
        {
            Dictionary<string, List<Tuple<string, double>>> compareResult = new Dictionary<string, List<Tuple<string, double>>>();

            var query = (from price in _pricesList
                    join item in _itemsList
                        on price.ItemId equals item.ItemId
                    join store in _storesList
                        on price.StoreId equals  store.StoreId
                    join chain in _chainsList
                        on store.ChainId equals chain.ChainId

                    select new
                    {
                        ChainId = chain.ChainId,
                        ChainName = chain.Name,
                        ItemName = item.Name,
                        Price =price.PriceItem 
                    }).Distinct();


            var queryChainGrouped = (from chainData in query
                orderby chainData.Price descending
                group chainData by chainData.ChainId
                into chainGroup
                select chainGroup.Take(3)).ToList();
                               
                // select chainGroup.OrderByDescending(obj => obj.Price).Take(3)).ToList();

            
            if (!flagMostExpensive)

            {
                queryChainGrouped = (from chainData in query
                    orderby chainData.Price
                    group chainData by chainData.ChainId
                    into chainGroup
                    select chainGroup.Take(3)).ToList();
                //select chainGroup.OrderBy(obj => obj.Price).Take(3)).ToList();
            }

            foreach (var chain in queryChainGrouped)
            {
                List<Tuple<string, double>> tempList = new List<Tuple<string, double>>();
                string chainName = "";

                foreach (var i in chain)
                {
                    chainName = i.ChainName;
                    tempList.Add(new Tuple<string, double>(i.ItemName, i.Price));
                }

                compareResult.Add(chainName, tempList);

            }

            return compareResult;
        }


        private List<Item> GetExtendedItems(List<Item> selectedItem)
        {
            List<Item> newItemsList =_unitOfWork.Items.GetExtendedItems(selectedItem);

            foreach (Item item in newItemsList)
            {
                item.Amount = selectedItem.Find(i => i.Name.Equals(item.Name)).Amount;
            }

            return newItemsList;
        }

        public Dictionary<string, List<Tuple<string, double>>> GetCartsTotalPricesPerStore(ShoppingCart shoppingCart)
        {
         
            Dictionary<string, List<Tuple<string, double>>> compareResult = new Dictionary<string, List<Tuple<string, double>>>();
            _itemsList = GetExtendedItems(shoppingCart.Items);
            _pricesList = _unitOfWork.Prices.GetPricesOfShoppingCart(_itemsList);
            _storesList = _unitOfWork.Stores.GetStores(_pricesList);
            _chainsList = _unitOfWork.Chains.GetChains(_storesList);

            var queryTotalPriceForStores = (from price in _pricesList
                                            group price by price.StoreId into priceGroup

                                            let sum = (from store in priceGroup
                                                       let price = store.PriceItem
                                                       select price * _itemsList.Find(i => i.ItemId == store.ItemId).Amount).Sum()
                                            select new
                                            {
                                                StoreId = priceGroup.Key,
                                                Sum = sum

                                            }
                         ).ToList();


            var queryTotalPriceForChains = (from store in _storesList
                                            join storePrice in queryTotalPriceForStores
                                                on store.StoreId equals storePrice.StoreId
                                            join chain in _chainsList
                                               on store.ChainId equals chain.ChainId

                                            select new
                                            {
                                                ChainId = chain.ChainId,
                                                ChainName = chain.Name,
                                                StoreName = store.Name,
                                                StoreId = store.StoreId,
                                                Sum = storePrice.Sum
                                            }).Distinct();


            var queryChainGrouped = (from chainData in queryTotalPriceForChains
                                     orderby chainData.Sum
                                     group chainData by chainData.ChainId
                                      into chainGroup
                                     select chainGroup);

            
            foreach (var chain in queryChainGrouped)
            {
                List< Tuple < string, double>> tempList  = new List<Tuple<string, double>>();
                string chainName = "";

                foreach (var i in chain)
                {
                    chainName = i.ChainName;
                    tempList.Add(new Tuple<string, double>(i.StoreName, i.Sum));
                }

                compareResult.Add(chainName,tempList);
                
            }
            
        
            return compareResult;

        }
    }
}
