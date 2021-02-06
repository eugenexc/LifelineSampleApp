using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppLifeline.DAL.Models
{
    public class Customer
    {
        public int CustomerID {get;set;}
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityID { get; set; }
        public string PostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }


        public City City { get; set; }
    }
}
