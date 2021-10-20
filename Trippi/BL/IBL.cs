using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrippiBL
    {
    public interface IBL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance">should be in km</param>
        /// <returns></returns>
         List<List<decimal>> GetNSEW(decimal latitude, decimal longitude, int distance);
    }
}
