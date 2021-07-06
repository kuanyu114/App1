 
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     public class CReceipt
    {
        //[PrimaryKey, AutoIncrement]
        public string recipeName { get; set; }
        public string recipeDescription { get; set; }
        public string Picture { get; set; }
    }
}
