using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Order
    {
       private int Id
        {
            get;
            set;
        }

        private int IdClient
        {
            get;
            set;
        }

       private DateTime OrderDate
        {
            get;
            set;
        }

        private double OrderAmount
        {
            get;
            set;
        }

        private bool OderPaid
        {
            get;
            set;
        }
    }
}