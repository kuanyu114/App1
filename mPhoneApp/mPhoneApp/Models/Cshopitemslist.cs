using System;
using System.Collections.Generic;
using System.Text;

namespace mPhoneApp.Models
{
    class Cshopitemslist
    {
        public int IngredientId { get; set; }
        public string Ingredient { get; set; }

        public string IngredientUnit { get; set; }
        public string Price
        {
            get { return _Price; }
            set { _Price = value+"元"; }
        }
        private string _Price;
       
        public string IngredientCategory { get; set; }
        public string MerchandisePicture {
            get { return _MerchandisePicture; }
            set { _MerchandisePicture = "https://deliciousmanagement.azurewebsites.net/img/IngredientPic/" + value; }
        }
        private string _MerchandisePicture;
    }
}
