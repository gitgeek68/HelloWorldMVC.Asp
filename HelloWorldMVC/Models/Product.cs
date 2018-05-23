using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Product
    {
      
        public string Reference//accesseur
        {
            get;
            set;
        }

        public string ProductName//accesseur
        {
            get;
            set;
        }
        public double ProductPrice//accesseur
        {
            get;
            set;
        }
        public string ProductDescription//accesseur
        {
            get;
            set;
        }

        public Product()//constructeur ppar defaut
        {

        }

        public Product(string _reference)//constructeur
        {
            this.Reference = _reference;
        }
    }
}