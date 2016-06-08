using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouncilServices.Models
{
    public class Basevm
    {
        protected string sortBy, sortOrder, sortOrderPage;
        protected int page = 0;
        protected int pageSize = 5;
        protected string sortByDefault = "";
        protected int pageDefault = 0;

        public int Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }

        public string SortBy
        {
            get
            {
                return sortBy == null ? sortByDefault : sortBy;
            }

            set
            {
                sortBy = value;
            }
        }


        public string SortOrder
        {
            get
            {
                return sortOrder;
            }

            set
            {
                sortOrder = value;
            }
        }

        public string SortOrderPage
        {
            get
            {
                return sortOrderPage = sortOrder == null ? "Desc" : (sortOrder == "Asc" ? "Desc" : "Asc");
            }

            set
            {
                sortOrderPage = value;
            }
        }


        public double TotalPages { get; set; }



        public Basevm(string sortBy, string sortOrder, string page)
        {
            this.page = int.Parse(page == null ? "1" : page);
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            this.TotalPages = pageDefault;
        }

        protected IEnumerable<T> updatePaging<T>(IEnumerable<T> items)
        {
            if (items == null) return null;
            this.TotalPages = Math.Ceiling(items.Count() / (double)pageSize);
            return items.Skip((this.page - 1) * pageSize).Take(pageSize);
        }
    }



    public class CustomersSortPageVM:Basevm
    {
        public readonly string Service = "Service";
        public readonly string CustomerType = "CustomerType";
        public readonly string QueuedAt = "QueuedAt";

        public bool IsAdmin { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public Customer CustomerHeadings { get; set; }

        Func<Customer, object> SortByFn;

        void updateSorting()
        {
            if (this.Customers == null) return;
            sortOrder = sortOrder == null ? "Asc" : (sortOrder == "Asc" ? "Desc" : "Asc");
            switch (this.sortOrder)
            {
                case "Asc":
                    Customers = Customers.OrderBy(SortByFn);
                    break;
                case "Desc":
                    Customers = Customers.OrderByDescending(SortByFn);
                    break;

                default:
                    Customers = Customers.OrderBy(SortByFn);
                    break;
            }
        }

        public CustomersSortPageVM(IEnumerable<Customer> customers, bool isAdmin, string sortBy, string sortOrder, string page)
            : base(sortBy, sortOrder, page)
        {
            this.IsAdmin = isAdmin;
            sortByDefault = this.QueuedAt;
            this.Customers = customers;
            if (sortBy == QueuedAt) SortByFn = s => s.QueuedAt;
            else if (sortBy == Service) SortByFn = s => s.Service.ToString();
            else if (sortBy == CustomerType) SortByFn = s => s.CustomerType.ToString();
            else { SortByFn = s => s.QueuedAt; }

            updateSorting();

            Customers = updatePaging<Customer>(Customers);
        }
    }
}