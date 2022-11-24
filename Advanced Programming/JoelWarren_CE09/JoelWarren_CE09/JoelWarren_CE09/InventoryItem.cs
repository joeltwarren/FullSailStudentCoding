using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE09
{
    class InventoryItem
    {
        private string _ItemDescription;
        private string _ItemType;
        private decimal _Price;
       

        public string ItemDescription
        {
            get { return _ItemDescription; }
        }

        public string ItemType
        {
            get { return _ItemType; }
        }

        public decimal Price
        {
            get { return _Price; }
        }

        public InventoryItem(string description, string type, decimal price)
        {
            _ItemDescription = description;
            _ItemType = type;
            _Price = price;
            
            Program.GetLogger().LogW($"Item: {_ItemDescription} was created.");
        }

        

       

        
    }
}
