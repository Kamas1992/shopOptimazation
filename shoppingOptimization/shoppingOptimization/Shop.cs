using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingOptimization
{
    class Shop
    {
        private List<Commodity> commodityList = new List<Commodity>();
        private ShopAddress address;

        Shop(ShopAddress address, List<Commodity> commodityList)
        {
            this.address = address;
            this.commodityList = commodityList;
        }
    }
}
