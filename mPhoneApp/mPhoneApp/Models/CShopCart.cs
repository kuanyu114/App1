using System;
using System.Collections.Generic;
using System.Text;

namespace mPhoneApp.Models
{
    class CShopCart
    {
        public int ingid { get; set; }
        public int cartQty { get; set; }
        public string ingredient { get; set; }
        public string unitprice { get; set; }
        public int amountInStore { get; set; }
        public string ingpicsrc { get; set; }
    }
}
