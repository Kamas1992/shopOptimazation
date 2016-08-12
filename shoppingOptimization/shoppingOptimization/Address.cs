using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingOptimization
{
    class Address
    {
        public static double r = 6378.41;

        public string geographicalCoordinates;
        private double longitude; // fi
        private double latitude; // lambda

        //cartesian coordiantes
        private double x;
        private double y;
        private double z;

        //geographical coordinates
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        //cartesian coordinates
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public Address()
        {

        }

        public Address(string geographicalCoordinates)
        {
            this.geographicalCoordinates = geographicalCoordinates;
            parseGeograpicalCoordinates();
            setCartesianCoordinatesBasedOnGeographical();
        }

        public void parseGeograpicalCoordinates()
        {
            int index = 0;
            for (int i = 0; i < geographicalCoordinates.Length; i++)
            {
                if (geographicalCoordinates[i] == ',')
                {
                    index = i;
                }
            }

            string sLatitude = changeDotToComma(geographicalCoordinates.Substring(1, index - 1));
            string sLongitude = changeDotToComma(geographicalCoordinates.Substring(index + 2, geographicalCoordinates.Length - index - 3));

            latitude = double.Parse(sLatitude);
            longitude = double.Parse(sLongitude);
        }

        public void setCartesianCoordinatesBasedOnGeographical()
        {
            double latitudeInRadian = Math.PI * latitude / 180;
            double longitudeInRadian = Math.PI * longitude / 180;

            this.x = r * Math.Cos(latitudeInRadian) * Math.Cos(longitudeInRadian);
            this.y = r * Math.Cos(latitudeInRadian) * Math.Sin(longitudeInRadian);
            this.z = r * Math.Sin(latitudeInRadian);
        }

        private string changeDotToComma(string value)
        {
            int index = value.IndexOf(".", 0);
            if (index != -1)
            {
                char[] tempCharArray = value.ToCharArray();
                tempCharArray[index] = ',';
                string result = new string(tempCharArray);
                return result;
            }
            else
            {
                return value;
            }
        }
    }
}
