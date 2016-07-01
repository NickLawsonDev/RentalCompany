using System;
using System.Collections.Generic;

namespace RentalCompany.Core.Models
{
    public class Customer
    {
        public Guid CustomerId
        {
            get
            {
                return System.Guid.NewGuid();
            }
        }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
