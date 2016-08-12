using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingOptimization
{
    class ShopAddress : Address
    {
        //shop parameters
        private string name;
        private int id;

        public ShopAddress ()
        {

        }

        public ShopAddress(string name, int id, string geographicalCoordinates) : base(geographicalCoordinates)
        {
            this.name = name;
            this.id = id;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
