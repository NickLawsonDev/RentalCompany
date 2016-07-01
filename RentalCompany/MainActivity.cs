using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RentalCompany.Core.Services;

namespace RentalCompany
{
    [Activity(Label = "Rental Company", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //Declares 2 Readonly Lazy Services to use
        private readonly Lazy<ReportService> ReportService;
        private readonly Lazy<PhotoService> PhotoService;

        //Instantiates both services
        public MainActivity()
        {
            ReportService =
                new Lazy<ReportService>(
                    () =>
                    {
                        return new ReportService();
                    });

            PhotoService =
                new Lazy<PhotoService>(
                    () =>
                    {
                        return new PhotoService();
                    });
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Sets our 2 buttons to the corresponding button on the view
            Button CreateReport = FindViewById<Button>(Resource.Id.CreateReport);
            Button FindReport = FindViewById<Button>(Resource.Id.FindReport);

            //Handles the clicking of the button and makes it redirect to the CreateReportActivity view
            CreateReport.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CreateReportActivity));
                StartActivity(intent);
            };
        }
    }
}

