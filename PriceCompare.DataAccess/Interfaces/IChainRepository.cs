using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public interface IChainRepository :IRepository<Chain>
    {
        Chain Get(string id);
        List<Chain> GetChains(List<Store> stores);
    }
}
