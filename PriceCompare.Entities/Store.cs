using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareDataAccess.Entities
{
    [Serializable]
    public class Store
    {
        public Store()
        {
           Prices = new List<Price>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int    StoreId      { get; set; }

        public int    StoreNumber  { get; set; }

        public string Name         { get; set; }

        public string Address      { get; set; }

        public string City         { get; set; }

        public string ZipCode      { get; set; }

        public string ChainId      { get; set; }

        public virtual Chain Chain { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        
    }
}
