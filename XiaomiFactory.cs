using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    internal class XiaomiFactory : IAbstractFactory
    {
        public IAbstractProductLaptop CreateProductLaptop()
        {
            return new ProductLatptopXiaomi();
        }

        public IAbstractProductTablet CreateProductTablet()
        {
            return new ProductTabletXiaomi();
        }
        public IAbstractProductPhone CreateProductPhone()
        {
            return new ProductPhoneXiaomi();
        }
    }
}
