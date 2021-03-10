using System;
using System.Net;
using CheckMate.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckMate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

          //  ServicePointManager.ServerCertificateValidationCallback += (o, cert, chain, errors) => true;



             MainPage = new MainPage();
            // MainPage = new Views.Checkin();
            // MainPage = new Views.AttendanceTracker();


            // var res = HttpHandler.GetAsync("/api/person").GetAwaiter().GetResult();
            //Console.WriteLine(res);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
