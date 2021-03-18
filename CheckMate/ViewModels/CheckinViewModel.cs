using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using CheckMate.Common;
using CheckMate.Models;
using CheckMate.Models.Joins;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using ZenWay.Models;

namespace CheckMate.ViewModels
{
    public class CheckinViewModel : INotifyPropertyChanged
    {
        public List<CurriculumModel> curriculm { get; set; } = CurriculumModel.allCurriculum;

        public CurriculumModel cur { get; set; }
        public CurriculumModel cur1 { get; set; }
        public CurriculumModel cur2 { get; set; }

        public string techniqueOne { get; set; }

        public Command CheckIn { private set; get; }

        public string header
        {
            get
            {
                string str = "Check Into Class \n";

                return str + DateTime.Today.ToString("d");
            }
        }
        public CheckinViewModel()
        {
            getLatestClass();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void getLatestClass()
        {
            HttpHandler hh = new HttpHandler();
            var x = hh.Get(@"/api/CurrentLesson/latest");
            var jsonString = x.Result;

            jsonString = jsonString.Replace("null", "-1");

            JObject obj = JObject.Parse(jsonString);
            GambitLessonModel.LatestLesson = GambitLessonModel.buildLesson(obj);

            if(obj["date"].ToString() == DateTime.Today.ToString("d"))
            {
                cur = CurriculumModel.allCurriculum[(int)obj["curriculum_id"]];

                if( (int)obj["curriculum1_id"] >= 0)
                {
                    cur1 = CurriculumModel.allCurriculum[(int)obj["curriculum1_id"]];

                    if ((int)obj["curriculum2_id"] >= 0)
                    {
                        cur2 = CurriculumModel.allCurriculum[(int)obj["curriculum2_id"]];
                    }
                }
            }
            
        }

        

    }
}
