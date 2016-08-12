using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationReader temp = new LocationReader(@"Locations\");
            temp.setLocations(); // set shopAdresses
            //temp.setStartAddress();

            List<string> shopsNames = temp.getShopsNames();
            List<string> shopsLocation = temp.getShopsLocations();
            List<int> shopsIds = temp.getShopsIds();
            List<ShopAddress> shopAdresses = temp.getShopAddresses();
            ShopAddress y = temp.getShopAddress(8);

            System.Console.WriteLine("Sex");
            System.Console.WriteLine("{0} {1}", y.Latitude, y.Longitude);
            foreach (string x in shopsNames)
            {
                System.Console.WriteLine("{0} ", x);
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();

            foreach (string x in shopsLocation)
            {
                System.Console.WriteLine("{0} ", x);
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();

            foreach (int x in shopsIds)
            {
                System.Console.WriteLine("{0} ", x);
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();

            foreach (ShopAddress x in shopAdresses)
            {
                System.Console.WriteLine("{0}, {1} {2}", x.Latitude, x.Longitude, x.Id);
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();

            double[,] tab = temp.getTableDistance();
            for(int i = 0; i < temp.getNumberOfShops(); i++)
            {
                for(int j = 0; j < temp.getNumberOfShops(); j++)
                {
                    System.Console.Write("\t {0} ", tab[i, j]);
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.ReadKey();
        }
    }
}
