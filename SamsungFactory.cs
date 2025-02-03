using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    internal class SamsungFactory:IAbstractFactory
    {
        public IAbstractProductLaptop CreateProductLaptop()
        {
            return new ProductLatptopSamsung();
        }

        public IAbstractProductTablet CreateProductTablet()
        {
            return new ProductTabletSamsung();
        }
        public IAbstractProductPhone CreateProductPhone()
        {
            return new ProductPhoneSamsung();
        }
    }
}
