using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareDataAccess.Entities
{
    [Serializable]
    public class Chain
    {
        public Chain()
        {
            Stores = new List<Store>();
        }
      
        public string ChainId { get; set; }

        public string Name    { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
