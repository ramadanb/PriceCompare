using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Logic
{
   public class CartSaveAndLoad
    {
        public void SaveShoppingCartToFile(ShoppingCart shoppingCart)
        {
            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();
            try
            {
                 stream = new FileStream("MyCart.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, shoppingCart);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                stream?.Close();
            }
        }

        public ShoppingCart LoadShoppingCartFromFile()
        {
            Stream stream = null;
            ShoppingCart shoppingCart = null;
            
            IFormatter formatter = new BinaryFormatter();
            try
            {

                stream = new FileStream("MyCart.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                shoppingCart = (ShoppingCart) formatter.Deserialize(stream);

            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                stream?.Close();

            }

            return shoppingCart;
        }
    }
}
