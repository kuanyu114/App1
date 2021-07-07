using System;
using System.Collections.Generic;
using System.Text;

namespace mPhoneApp.Models
{
    class COrder
    {
       
        public int memberId { get; set; }
         
        public string reciever { get; set; }
        public string phoneNumber { get; set; }
        public string deliveryCounty { get; set; }
        public string deliveryDistrict { get; set; }
        public string deliveryAddress { get; set; }
       
       
    }
}
