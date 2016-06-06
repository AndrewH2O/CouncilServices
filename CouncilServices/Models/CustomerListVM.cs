using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouncilServices.Models
{
    public class CustomerListVM
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public Customer CustomerHeadings { get; set; }
    }
}