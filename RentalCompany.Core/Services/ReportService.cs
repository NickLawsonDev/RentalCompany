using RentalCompany.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentalCompany.Core.Services
{
    /*
     * Started working on the database but ran out of time. Want to work on this later.
    */
    public class ReportService
    {
        SQLiteConnection db = null;

        //Old way of doing it.
        public Customer Customer = new Customer();


        public ReportService()
        {
            db = new SQLiteConnection(db.DatabasePath);
            db.CreateTable<Report>();
        }

        //Grabs the reports by selecting ones that have the same Customer Id as our customer object
        public IEnumerable<Report> GetReports()
        {
            return Customer
                   .Reports
                   .Where(e => e.CustomerId == Customer.CustomerId)
                   .Select(
                    e =>
                        new Report
                        {
                            CustomerId = Customer.CustomerId,
                            ReportId = e.ReportId,
                            RentalAgreementNumber = e.RentalAgreementNumber,
                            CustomerName = e.CustomerName,
                            CustomerEmail = e.CustomerEmail,
                            LicensePlateNumber = e.LicensePlateNumber,
                            CreatedUTC = e.CreatedUTC
                        })
                    .ToArray();
        }

        //Gets a report by checking the CustomerId and the ReportId
        public Report GetReportById (Guid id)
        {
            Report entity;
            entity = Customer
                     .Reports
                     .SingleOrDefault(e => e.CustomerId == Customer.CustomerId && e.ReportId == id);

            return
                new Report
                {
                    CustomerId = Customer.CustomerId,
                    ReportId = entity.ReportId,
                    RentalAgreementNumber = entity.RentalAgreementNumber,
                    CustomerName = entity.CustomerName,
                    CustomerEmail = entity.CustomerEmail,
                    LicensePlateNumber = entity.LicensePlateNumber,
                    CreatedUTC = entity.CreatedUTC
                };
        }

        //Creates a report with the passed in parameters
        public Report CreateReport(Report report)
        {
            var entity =
                new Report
                {
                    CustomerId = Customer.CustomerId,
                    ReportId = System.Guid.NewGuid(),
                    RentalAgreementNumber = report.RentalAgreementNumber,
                    CustomerName = report.CustomerName,
                    CustomerEmail = report.CustomerEmail,
                    LicensePlateNumber = report.LicensePlateNumber,
                    CreatedUTC = DateTimeOffset.UtcNow
                };
            Customer.Reports.Add(entity);

            return entity;
        }

        //Deletes a report based on the CustomerId and Id passed in
        public void DeleteReport(Guid id)
        {
            var entity =
                Customer
                    .Reports
                    .SingleOrDefault(e => e.CustomerId == Customer.CustomerId && e.ReportId == id);

            Customer.Reports.Remove(entity);
        }
    }
}
