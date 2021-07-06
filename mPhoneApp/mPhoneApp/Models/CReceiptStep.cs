using System;
using System.Collections.Generic;
using System.Text;

namespace mPhoneApp.Models
{
    class CReceiptStep
    {
        

        private string _Picture = "";   
        public string stepsNumber { get; set; }
        public string steps { get; set; }
        public string picture
        {
            get { return _Picture; }
            set { _Picture = "aa" + value; }
        }
    }
}
