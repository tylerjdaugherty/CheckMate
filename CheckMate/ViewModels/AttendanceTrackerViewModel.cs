using System;
using System.Collections.Generic;
using System.Linq;
using CheckMate.Common;
using CheckMate.Models.Joins;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZenWay.Models;

namespace CheckMate.ViewModels
{
    public class AttendanceTrackerViewModel
    {
        public List<CurriculumCounter> curriculm { get; set; } = new List<CurriculumCounter>();
        private int count = 0;
        public string lesson_count
        {
            get
            {
                return "Total Classes: " + count.ToString();
            }
        }


        public AttendanceTrackerViewModel()
        {
            string json = "{id : 1, Name : 'Take Downs'}";
            CurriculumModel cm = JsonConvert.DeserializeObject<CurriculumModel>(json);


            // Linked Lists for checkin page
            // curriculm will be used as main object
            // Count for each item in curriculm


            getCurriculum();
            getCurriculumCount(getLessons());

        }

        void getCurriculumCount(List<LessonModel> lessons)
        {
            foreach (var cur in curriculm)
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
                    this.curriculm.Add(cm);
            }
        }

        List<LessonModel> getLessons(int studentID = 1)
        {
            var lessons = new List<LessonModel>();
            HttpHandler hh = new HttpHandler();
            var x = hh.Get(@"/api/LessonCount/" + studentID.ToString());
            var jsonString = x.Result;

            JArray jsonArray = JArray.Parse(jsonString);

            foreach (JObject obj in jsonArray)
            {
                count++;
                var lesson = new LessonModel();
                lesson.lesson_id = (int)obj["class_id"];
                lesson.curriculum = (string)obj["curriculum"];
                lesson.curriculum1 = (string)obj["curriculum1"];
                lesson.curriculum2 = (string)obj["curriculum2"];
                lessons.Add(lesson);
            }
            return lessons;
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
        }
    }
}
