using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DiscountService
    {
        public int CalcDiscount(int totalQuantity)
        {
            if(totalQuantity <= 300000) return 15;
            if(totalQuantity <= 50000) return 10;
            if (totalQuantity <= 10000) return 5;
            return 0;
        }
    }
}
