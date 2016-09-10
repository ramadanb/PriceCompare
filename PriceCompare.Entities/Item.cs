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
    public class Item
    {
        public Item()
        {
            Prices = new List<Price>();
        }

       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int    ItemId       { get; set; }
            
        public string ItemCode     { get; set; } //Barcode number or internal code

        public int    ItemType     { get; set; } //0 for internal codes, 1 for barcodes

        public string ChainId      { get; set; } // Empty string for universal

        public string Name         { get; set; }

        public string UnitQuantity { get; set; }

        public double Quantity     { get; set; } //Quantity of units in a package

        public bool   IsWeighted   { get; set; }

        [NotMapped]
        public int Amount          { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

    }
}
