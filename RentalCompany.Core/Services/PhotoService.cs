using RentalCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalCompany.Core.Services
{
    public class PhotoService
    {
        //This simulates how you would use a database
        public static Customer Customer { get; set; }

        //Grabs the photos by selecting ones that have the same ReportId as the passed in parameter
        public IEnumerable<Photo> GetPhotos(Guid ReportId)
        {
            return Customer
                   .Photos
                   .Where(e => e.ReportId == ReportId)
                   .Select(
                    e =>
                        new Photo
                        {
                            PhotoId = e.PhotoId,
                            ReportId = e.ReportId,
                            ImagePath = e.ImagePath
                        })
                    .ToArray();
        }

        //Gets a Photo by checking the PhotoId and PhotoId
        public Photo GetPhotoById(Guid PhotoId, Guid ReportId)
        {
            Photo entity;
            entity = Customer
                     .Photos
                     .SingleOrDefault(e => e.ReportId == ReportId && e.PhotoId == PhotoId);

            return
                new Photo
                {
                    PhotoId = entity.PhotoId,
                    ReportId = entity.ReportId,
                    ImagePath = entity.ImagePath
                };
        }

        //Creates a Photo with the passed in parameters
        public void CreatePhoto(Photo Photo, Guid ReportId)
        {
            var entity =
                new Photo
                {
                    ReportId = ReportId,
                    PhotoId = System.Guid.NewGuid(),
                    ImagePath = Photo.ImagePath
                };
            Customer.Photos.Add(entity);
        }

        //Deletes a Photo based on the ReportId and PhotoId passed in
        public void DeletePhoto(Guid PhotoId, Guid ReportId)
        {
            var entity =
                Customer
                    .Photos
                    .SingleOrDefault(e => e.ReportId == ReportId && e.PhotoId == PhotoId);

            Customer.Photos.Remove(entity);
        }
    }
}
