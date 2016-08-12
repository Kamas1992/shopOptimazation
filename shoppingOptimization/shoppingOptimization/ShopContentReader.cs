using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingOptimization
{
    class ShopContentReader
    {
        private List<Shop> shopList; //list of shops with commodities
        private string nameOfDirectory; //name of data directory

        public ShopContentReader()
        {

        }

        public ShopContentReader(List<Shop> shopList)
        {
            this.shopList = shopList;
        }

        public ShopContentReader(string nameOfDirectory)
        {
            this.nameOfDirectory = nameOfDirectory;
        }
    }
}
