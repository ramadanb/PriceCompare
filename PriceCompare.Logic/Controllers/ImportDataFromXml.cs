using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml.Linq;
using PriceCompare.DataAccess;
using PriceCompareDataAccess.Entities;


namespace PriceCompare.Logic
{
    public class ImportDataFromXml
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _xmlPriceFilesPath;
        private readonly string _xmlStoreFilesPath;
        private readonly string _xmlChainFilesPath;

        private List<string> _xmlPriceFilesPaths;
        private List<string> _xmlStoreFilesPaths;
        private List<string> _xmlChainFilesPaths;


        public ImportDataFromXml(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _unitOfWork = unitOfWork;

            _xmlPriceFilesPath = @"..\..\..\resources\";
            _xmlStoreFilesPath = @"..\..\..\resources\Stores";
            _xmlChainFilesPath = @"..\..\..\resources\Chains";

        }

        public void Initialize()
        {
            try
            {
                _xmlPriceFilesPaths = Directory.GetFiles(_xmlPriceFilesPath).ToList();
                _xmlStoreFilesPaths = Directory.GetFiles(_xmlStoreFilesPath).ToList();
                _xmlChainFilesPaths = Directory.GetFiles(_xmlChainFilesPath).ToList();
                
            }
            catch (DirectoryNotFoundException ex)
            {

                throw ex;
            }


            foreach (var xmlChainPath in _xmlChainFilesPaths)
            {
                XDocument xmlChainsDocument = XDocument.Load(xmlChainPath);

                ImportChainsAndAddToDB(xmlChainsDocument);
            }

            foreach (var xmlStorePath in _xmlStoreFilesPaths)
            {          
                XDocument xmlStoreDocument = XDocument.Load(xmlStorePath);

                ImportStoresAndAddToDB(xmlStoreDocument);
            }

            foreach (var xmlPriceFile in _xmlPriceFilesPaths)
            {
                XDocument xmlPriceDocument = XDocument.Load(xmlPriceFile);

                ImportItemsAndAddToDB(xmlPriceDocument);
            }

        }

        private void ImportChainsAndAddToDB(XDocument document)
        {

            if (document == null)
                throw new ArgumentNullException(nameof(document));

            try
            {
                IEnumerable<Chain> chains =
                 from c in document.Descendants("chain")
                 select new Chain
                 {
                     ChainId = c.Element("ChainId") == null ? null : c.Element("ChainId").Value,
                     Name = c.Element("ChainName") == null ? null : c.Element("ChainName").Value,


                 };

                foreach (var chain in chains)
                {
                    
                    _unitOfWork.Chains.AddIfNotExists(chain, c => c.ChainId == chain.ChainId);

                }

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
        }

        private void ImportStoresAndAddToDB(XDocument document)
        {

            if (document == null)
                throw new ArgumentNullException(nameof(document));

           string chainId = document.Descendants("ChainId").First().Value;

           Chain chain = _unitOfWork.Chains.Get(chainId);

           IEnumerable<Store> stores =
                from s in document.Descendants("Store")
                select new Store
                {
                    StoreNumber = s.Element("StoreId") == null ? 0 : int.Parse(s.Element("StoreId").Value),
                    Name = s.Element("StoreName") == null ? null : s.Element("StoreName").Value,
                    Address = s.Element("Address") == null ? null : s.Element("Address").Value,
                    City = s.Element("City") == null ? null : s.Element("City").Value,
                    ZipCode = s.Element("ZipCode") == null ? null : s.Element("ZipCode").Value,
                  
                };

            foreach (Store store in stores)
            {
                chain.Stores.Add(store);
            }


            _unitOfWork.Complete();

        }

        private void ImportItemsAndAddToDB(XDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            var items =
                from i in document.Descendants("Item")
                let itemType = i.Element("ItemType") == null ? 0 : int.Parse(i.Element("ItemType").Value) == 0 ? 0 : 1
                let isWheighted=i.Element("bIsWeighted") == null ? false : int.Parse(i.Element("bIsWeighted").Value) == 0 ? false : true
                select new 
                {
                    item = new Item()
                    { 
                    ItemCode = i.Element("ItemCode") == null ? null : i.Element("ItemCode").Value,
                    ItemType = itemType,
                    ChainId  = (itemType == 0 || isWheighted) ? document.Descendants("ChainId").First().Value : "",
                    Name    = i.Element("ItemName")==null ? null : i.Element("ItemName").Value,
                    UnitQuantity = i.Element("UnitQty") == null ? null : i.Element("UnitQty").Value,
                    Quantity = i.Element("Quantity") == null  ? 0 : double.Parse(i.Element("Quantity").Value),
                    IsWeighted = isWheighted
                    }
                    
                    ,price = i.Element("ItemPrice") == null ? 0:double.Parse(i.Element("ItemPrice").Value)
                    ,storeId= int.Parse(document.Descendants("StoreId").First().Value)
                    ,ChainId= document.Descendants("ChainId").First().Value


                };

            foreach (var itemObj in items)
            {

                Item item =  _unitOfWork.Items.AddIfNotExists(itemObj.item,
                    i => (i.ItemCode == itemObj.item.ItemCode && i.IsWeighted == false && i.ItemType == 1));

                
                if (item == null)
                {
                    item = _unitOfWork.Items.Get(itemObj.item.ItemCode);

                }

                item.Prices.Add(new Price()
                {
                    
                    PriceItem = itemObj.price,
                    StoreId = _unitOfWork.Stores.GetStore(itemObj.storeId, itemObj.ChainId).StoreId

                });
            }

            _unitOfWork.Complete();
        }
    }
}
