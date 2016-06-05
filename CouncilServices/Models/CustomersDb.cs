using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CouncilServices.Models
{
    public class CustomersDb:DbContext
    {
        public CustomersDb():base("name=customersAppConn")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}