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
    public class Price
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int    PriceId   { get; set; }

        public int    StoreId   { get; set; }

        public int    ItemId    { get; set; }

        public double PriceItem { get; set; }


        public virtual Item Item   { get; set; }

        public virtual Store Store { get; set; }


    }
}
