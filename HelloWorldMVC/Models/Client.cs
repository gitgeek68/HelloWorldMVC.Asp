using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Client
    {
        private string lastName;
        private string firstName;
        private int id;

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Client()
        {

        }

        public Client(int _id,string _lastName,string _firstname)
        {
            this.lastName = _lastName;
            this.firstName = _firstname;
            this.id = _id;

        }
        
       
    }
}
