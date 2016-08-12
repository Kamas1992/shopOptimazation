using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace shoppingOptimization
{
    class LocationReader
    {
        private List<Address> addresses = new List<Address>();
        private List<ShopAddress> shopAddresses = new List<ShopAddress>();
        //content of File
        private Address startLocation;
        private List<string> shopsNames = new List<string>();
        private List<string> shopsLocation = new List<string>(); // (X, Y)
        private List<int> shopsIds = new List<int>();
        private int numberOfShops;

        //lines of Content In File
        private string nameOfDirectory;
        private string [] lines;

        public LocationReader(string nameOfDirectory)
        {
            this.nameOfDirectory = nameOfDirectory;
        }

        public ShopAddress getShopAddress(int id)
        {
            ShopAddress result = new ShopAddress();
            foreach (ShopAddress address in shopAddresses)
            {
                if(address.Id == id)
                {
                    result = address;
                }
            }
            return result;
        }

        public int getNumberOfShops()
        {
            return numberOfShops;
        }

        public string NameOfDirectory
        {
            get
            {
                return nameOfDirectory;
            }
            set
            {
                nameOfDirectory = value;
            }
        }

        public List<Address> getAddresses()
        {
            return addresses;
        }

        public void setLocations() // set adresses basen on location files
        {
            setShopAdresses(); //set shop adresses in list
            setStartAddress(); //set start address
            addresses.Add(startLocation); // add start address to list  
        }

        public void setShopAdresses()
        {
            List<string> filesNames = getFilesNames(nameOfDirectory);
            setLines(filesNames[0]);
            setShopsNames();
            setShopsLocations();
            setShopsIds();
        
            for (int i = 0; i < numberOfShops; i++)
            {
                ShopAddress objectToAdd = new ShopAddress(shopsNames[i], shopsIds[i], shopsLocation[i]);
                objectToAdd.parseGeograpicalCoordinates();
                objectToAdd.setCartesianCoordinatesBasedOnGeographical();
                addresses.Add(objectToAdd);
                shopAddresses.Add(objectToAdd);
            }
        }

        public List<ShopAddress> getShopAddresses()
        {
            return shopAddresses;
        }

        public void setStartAddress()
        {
            List<string> filesNames = getFilesNames(nameOfDirectory);
            string fileName = filesNames[1];
            lines = System.IO.File.ReadAllLines(fileName);
            string coordinates = lines[0];
            startLocation = new Address(coordinates);
        }

        public Address getStartAddress()
        {
            return startLocation;
        }

        public void setLines(string nameOfFile)
        {
            lines = System.IO.File.ReadAllLines(nameOfFile);
            numberOfShops = lines.Length - 1;
        }

        public List<string> getShopsNames()
        {
            return shopsNames;
        }

        public void setShopsNames()
        {
            int first = 0;
            int last = 0;
            int length;

            foreach(string line in lines)
            {
               for(int i = 0; i < line.Length; i++)
               {
                    if(line[i] == '[')
                    {
                        first = i;
                    }

                    if(line[i] == ']')
                    {
                        last = i;
                    }

                    if(first != 0 && last != 0)
                    {
                        break;
                    }
               }

               length = Math.Abs(last - first);

               if(length != 0)
               {
                    shopsNames.Add(line.Substring(first + 1, length - 1));
               }

               first = 0;
               last = 0;
            }
        }

        public List<int> getShopsIds()
        {
            return shopsIds;
        }

        public void setShopsIds()
        {
            char delimeter = ' ';
            int cnt = 0;

            foreach(string line in lines)
            {
                if(cnt == 0)
                {
                    cnt++;
                    continue;
                }
                string[] subString = line.Split(delimeter);
                shopsIds.Add(Int32.Parse(subString[0]));
            }
        }

        public List<string> getShopsLocations()
        {
            return shopsLocation;
        }

        public void setShopsLocations()
        {
            int first = 0;
            int last = 0;
            int length;

            foreach (string line in lines)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if(line[i] == '(')
                    {
                        first = i;
                    }

                    if(line[i] == ')')
                    {
                        last = i;
                    }

                    if (first != 0 && last != 0)
                    {
                        break;
                    }
                }

                length = Math.Abs(last - first);

                if(length != 0)
                {
                    shopsLocation.Add(line.Substring(first, length + 1));
                }

                first = 0;
                last = 0;
            }
        }

        public double [,] getTableDistance() // creates table that contain distances between shops
        {
            double[,] array = new double[numberOfShops + 1, numberOfShops + 1]; //due to start location
            for(int i = 0; i < addresses.Count; i++)
            {
                for(int j = 0; j < addresses.Count; j++)
                {
                    if(i == j)
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        array[i, j] = calculateDistance(addresses[i], addresses[j]);
                    }
                }
            }

            return array;
        }

        private double calculateDistance(Address source, Address destination) //calculate disntance between two cities source and destination
        {
            double R = Address.r;
            double d = Math.Sqrt(Math.Pow((source.X - destination.X), 2) + Math.Pow((source.Y - destination.Y), 2) + Math.Pow((source.Z - destination.Z), 2)); //euclidian distance beetween two cities
            double cosfi = 1 - (Math.Pow(d, 2)) / (2 * Math.Pow(R, 2));
            double fi = Math.Acos(cosfi);
            double normalizedFi = 180 * fi / Math.PI;
            double result = normalizedFi * Math.PI * R / 180;
            return result;
        }

        private List<string> getFilesNames(string path) //function return files in directory
        {
            Directory.GetFiles(path);
            List<string> pliki = Directory.GetFiles(path).ToList<string>();
            return pliki;
        }

    }
}
