using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public class ChainRepository:Repository<Chain>,IChainRepository
    {
       public ChainRepository(DbContext context) : base(context)
       {
       }

       public Chain Get(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw  new ArgumentException(nameof(id));
            }
         
             return DbSet.Find(id);
        }

       public List<Chain> GetChains(List<Store> stores)
        {
           if (stores == null)
           {
               throw new Exception(nameof(stores));
           }

           List<Chain> listChains = new List<Chain>();

           foreach (Store store in stores)
           {
               List<Chain> tempList = DbSet.Where(c=>c.ChainId==store.ChainId).ToList();

               listChains = listChains.Concat(tempList).ToList();
           }

           return listChains;
        }


    }
}
