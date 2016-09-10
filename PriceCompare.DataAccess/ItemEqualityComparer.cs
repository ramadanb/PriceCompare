using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess
{
    public class ItemEqualityComparer: IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x) + nameof(y));
            }

            return x.Name.ToLower().Equals(y.Name.ToLower());
        }

        public int GetHashCode(Item obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Name.GetHashCode();
        }
    }
}
