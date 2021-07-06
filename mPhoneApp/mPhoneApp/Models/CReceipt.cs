 
using System;
using System.Collections.Generic;
using System.Text;

namespace mPhoneApp.Models
{
     public class CReceipt
    {
        private string _Picture = "";
        public int recipeId { get; set; }
        public string recipeName { get; set; }
        public string recipeDescription { get; set; }
        public string Picture { 
            get { return _Picture; } 
            set {_Picture= "https://prjdelicious.azurewebsites.net/" + value;} }


    }
}
