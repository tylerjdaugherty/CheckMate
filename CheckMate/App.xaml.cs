using System;
using System.Net;
using CheckMate.Common;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZenWay.Models;

namespace CheckMate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //  ServicePointManager.ServerCertificateValidationCallback += (o, cert, chain, errors) => true;

            getCurriculum();

            // MainPage = new MainPage();
            MainPage = new Views.Checkin();
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

        void getCurriculum()
        {
            HttpHandler hh = new HttpHandler();
            var x = hh.Get(@"/api/Curriculum");
            var jsonString = x.Result;

            JArray jsonArray = JArray.Parse(jsonString);
            foreach (JObject obj in jsonArray)
            {

                var cm = new CurriculumModel();
                cm.id = (int)obj["id"];
                cm.name = (string)obj["name"];
                if (!String.IsNullOrEmpty(cm.name))
                    CurriculumModel.allCurriculum.Add(cm);
            }
        }
    }
}
