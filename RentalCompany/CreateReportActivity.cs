
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using RentalCompany.Core.Models;
using RentalCompany.Core.Services;
using System;

namespace RentalCompany
{
    [Activity(Label = "CreateReportActivity")]
    public class CreateReportActivity : Activity
    {
        //Declares 2 Readonly Lazy Services to use
        private readonly Lazy<ReportService> ReportService;
        private readonly Lazy<PhotoService> PhotoService;

        //Instantiates both services
        public CreateReportActivity()
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.CreateReport);

            //Sets our 3 buttons to the corresponding button on the view
            Button PictureButton = FindViewById<Button>(Resource.Id.PictureButton);
            Button SubmitButton = FindViewById<Button>(Resource.Id.SubmitButton);
            Button CancelButton = FindViewById<Button>(Resource.Id.CancelButton);

            SubmitButton.Click += (sender, e) =>
            {
                //Grabs all of our User Input Fields
                EditText RentalAgreementNumber = FindViewById<EditText>(Resource.Id.RANField);
                EditText CustomerName = FindViewById<EditText>(Resource.Id.CustomerNameField);
                EditText CustomerEmail = FindViewById<EditText>(Resource.Id.CustomerEmailField);
                EditText LicensePlateNumber = FindViewById<EditText>(Resource.Id.LicensePlateNumberField);

                //Sends all the data that I need.
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("RentalAgreementNumber", int.Parse(RentalAgreementNumber.Text));
                intent.PutExtra("CustomerName", CustomerName.Text);
                intent.PutExtra("CustomerEmail", CustomerEmail.Text);
                intent.PutExtra("LicensePlateNumber", int.Parse(LicensePlateNumber.Text));
                StartActivity(intent);
            };

            CancelButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}