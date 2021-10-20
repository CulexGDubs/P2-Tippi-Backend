using System;
using DL;
using DecimalMath; //https://github.com/nathanpjones/DecimalMath
using System.Collections.Generic;

namespace TrippiBL
    {
    public class BL : IBL


    {
        //private readonly IRepo _repo;
        //public BL(IRepo repo)
        //    {
        //    _repo = repo;
        //    }


        public List<decimal> GetW(decimal latitude, decimal longitude, int distance)
        {
            List<decimal> West = new List<decimal>();

            //convert to radians
            decimal radlatitude = (latitude * (decimal)Math.PI) / 180;
            longitude = (longitude * (decimal)Math.PI) / 180;
            //convert to nautical miles
            decimal nauticaldistance = (decimal)(distance / 1.852);
            //convert to radians
            decimal raddistance = (decimal)(nauticaldistance * (decimal)(Math.PI / (180 * 60)));
            West.Add(latitude);
            decimal lon2;
            // decimal a = (DecimalEx.Sqrt((DecimalEx.Pow((DecimalEx.Sin(raddistance / 2)), 2) - DecimalEx.Pow((DecimalEx.Sin((0) / 2)), 2)) / (DecimalEx.Cos(latitude) * DecimalEx.Cos(latitude))));
            // System.Console.WriteLine(a);
            lon2 = longitude -2 * DecimalEx.ASin(DecimalEx.Sqrt((DecimalEx.Pow((DecimalEx.Sin(raddistance / 2)), 2) - DecimalEx.Pow((DecimalEx.Sin((0) / 2)), 2)) / (DecimalEx.Cos(radlatitude) * DecimalEx.Cos(radlatitude))));
            West.Add(lon2 * (decimal)(180 / Math.PI));
            return West;
        }

          public List<decimal> GetE(decimal latitude, decimal longitude, int distance)
        {
            List<decimal> East = new List<decimal>();

            //convert to radians
            decimal radlatitude = (latitude * (decimal)Math.PI) / 180;
            longitude = (longitude * (decimal)Math.PI) / 180;
            //convert to nautical miles
            decimal nauticaldistance = (decimal)(distance / 1.852);
            //convert to radians
            decimal raddistance = (decimal)(nauticaldistance * (decimal)(Math.PI / (180 * 60)));
            East.Add(latitude);
            decimal lon2;
            // decimal a = (DecimalEx.Sqrt((DecimalEx.Pow((DecimalEx.Sin(raddistance / 2)), 2) - DecimalEx.Pow((DecimalEx.Sin((0) / 2)), 2)) / (DecimalEx.Cos(latitude) * DecimalEx.Cos(latitude))));
            // System.Console.WriteLine(a);
            lon2 = longitude + 2 * DecimalEx.ASin(DecimalEx.Sqrt((DecimalEx.Pow((DecimalEx.Sin(raddistance / 2)), 2) - DecimalEx.Pow((DecimalEx.Sin((0) / 2)), 2)) / (DecimalEx.Cos(radlatitude) * DecimalEx.Cos(radlatitude))));
            East.Add(lon2 * (decimal)(180 / Math.PI));
            return East;
        }
      
        public List<List<decimal>> GetNSEW(decimal latitude, decimal longitude, int distance)
        {
            List<List<decimal>> NSEW = new List<List<decimal>>();

           

            decimal dd = (decimal)distance;
            List<decimal> North = new List<decimal>(){latitude + (decimal)(dd / 111), longitude};
            
            List<decimal> South = new List<decimal>(){latitude - (decimal)(dd / 111), longitude};

            List<decimal> East = GetW(latitude, longitude, distance);

            List<decimal> West = GetW(latitude, longitude, distance);

            NSEW.Add(North);
            NSEW.Add(South);
            NSEW.Add(East);
            NSEW.Add(West);

            // arranging formula from http://edwilliams.org/avform147.htm#Dist
            // d =2 * asin(sqrt((sin((lat1 - lat2) / 2))^2 + cos(lat1) * cos(lat2) * (sin((lon1 - lon2) / 2))^2))
            
            // d / 2 = asin(sqrt((sin((lat1 - lat2) / 2))^2 + cos(lat1) * cos(lat2) * (sin((lon1 - lon2) / 2))^2))

            // sin(d / 2) = sqrt((sin((lat1 - lat2) / 2))^2 + cos(lat1) * cos(lat2) * (sin((lon1 - lon2) / 2))^2)

            // (sin(d / 2))^2 = (sin((lat1 - lat2) / 2))^2 + cos(lat1) * cos(lat2) * (sin((lon1 - lon2) / 2))^2

            // (sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2 = cos(lat1) * cos(lat2) * (sin((lon1 - lon2) / 2))^2

            // ((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2)) = (sin((lon1 - lon2) / 2))^2

            // sqrt(((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2))) = sin((lon1 - lon2) / 2)

            // asin(sqrt(((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2)))) = (lon1 - lon2) / 2

            // 2 * asin(sqrt(((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2)))) = -lon2 + lon1

            //  2 * asin(sqrt(((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2)))) - lon1 = -lon2

             //lon2 = lon1 -2 * asin(sqrt(((sin(d / 2))^2 - (sin((lat1 - lat2) / 2))^2) / (cos(lat1) * cos(lat2))))

            return NSEW;
        }
    }
}
