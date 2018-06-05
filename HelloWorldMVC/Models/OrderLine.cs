using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HelloWorldMVC.Models
{
    public class OrderLine
    {

        public int Id
        {
            get;

            set;
        }
        public int IdOrder
        {
            get;
            set;
        }
        public int IdProduct
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }

        public OrderLine()
        {
         

        }

    }
}