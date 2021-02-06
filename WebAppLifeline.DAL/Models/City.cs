using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebAppLifeline.DAL.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Province { get; set; }
        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
    }
}
