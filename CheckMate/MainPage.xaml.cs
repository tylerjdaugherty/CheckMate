using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZenWay.Models;
using CheckMate.Common;
using Newtonsoft.Json.Linq;
using CheckMate.Models.Joins;

namespace CheckMate
{
    public partial class MainPage : ContentPage
    {
        List<CurriculumCounter> curriculm = new List<CurriculumCounter>();

        public MainPage()
        {
            InitializeComponent();

            // Linked Lists for checkin page
            // curriculm will be used as main object
            // Count for each item in curriculm


            getCurriculum();
            getCurriculumCount(getLessons());
            
        }

        void getCurriculumCount(List<LessonModel> lessons)
        {
            foreach(var cur in curriculm)
            {
                var complete = lessons.Where(l => l.curriculum == cur.name).Count();
                cur.count = complete;
            }
            
        }

        void getCurriculum()
        {
            HttpHandler hh = new HttpHandler();
            var x = hh.Get(@"/api/Curriculum");
            var jsonString = x.Result;

            JArray jsonArray = JArray.Parse(jsonString);
            foreach (JObject obj in jsonArray)
            {

                CurriculumCounter cm = new CurriculumCounter();
                cm.id = (int)obj["id"];
                cm.name = (string)obj["name"];
                if (!String.IsNullOrEmpty(cm.name))
                    curriculm.Add(cm);
            }
        }

        List<LessonModel> getLessons(int studentID = 1)
        {
            var lessons = new List<LessonModel>();
            HttpHandler hh = new HttpHandler();
            var x = hh.Get(@"/api/LessonCount/" + studentID.ToString());
            var jsonString = x.Result;

            JArray jsonArray = JArray.Parse(jsonString);

            foreach(JObject obj in jsonArray)
            {
                var lesson = new LessonModel();
                lesson.lesson_id = (int)obj["class_id"];
                lesson.curriculum = (string)obj["curriculum"];
                lesson.curriculum1 = (string)obj["curriculum1"];
                lesson.curriculum2 = (string)obj["curriculum2"];
                lessons.Add(lesson);
            }
            return lessons;
        }
    }
}
