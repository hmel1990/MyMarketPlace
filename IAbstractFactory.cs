using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    public interface IAbstractFactory
    {
        IAbstractProductLaptop CreateProductLaptop();

        IAbstractProductTablet CreateProductTablet();
        IAbstractProductPhone CreateProductPhone();
    }
}
