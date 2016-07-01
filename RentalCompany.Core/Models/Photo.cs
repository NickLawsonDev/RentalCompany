using System;

namespace RentalCompany.Core.Models
{
    public class Photo
    {
        public Guid ReportId { get; set; }
        public Guid PhotoId { get; set; }
        public string ImagePath { get; set; }
    }
}
