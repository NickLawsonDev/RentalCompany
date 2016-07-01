using System;
using System.Collections.Generic;
using SQLite;

namespace RentalCompany.Core.Models
{
    public class Report
    {
        //All the variables for the Report
        [PrimaryKey]
        public Guid CustomerId { get; set; }
        public Guid ReportId { get; set; }
        public int RentalAgreementNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int LicensePlateNumber { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }

        //Collection of Images
        ICollection<Photo> Images { get; set; }
    }
}
