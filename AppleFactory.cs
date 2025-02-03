using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    internal class AppleFactory : IAbstractFactory
    {
        public IAbstractProductLaptop CreateProductLaptop()
        {
            return new ProductLatptopApple();
        }

        public IAbstractProductTablet CreateProductTablet()
        {
            return new ProductTabletApple();
        }
        public IAbstractProductPhone CreateProductPhone()
        {
            return new ProductPhoneApple();
        }
    }
}
