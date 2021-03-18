using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CheckMate.Models;
using CheckMate.ViewModels;
using Xamarin.Forms;
using ZenWay.Models;

namespace CheckMate.Views
{
    public partial class Checkin : ContentPage
    {
        public Checkin()
        {
            InitializeComponent();
            BindingContext = new CheckinViewModel();
        }

        void checkInButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
            var lesson = new LessonModel();
            if (techniqueOne_picker.SelectedIndex != -1)
            {
                // Populate CurriculumModel from GUI
                lesson.curriculum = CurriculumModel.allCurriculum[techniqueOne_picker.SelectedIndex].name;
                if (techniqueTwo_picker.SelectedIndex != -1)
                    lesson.curriculum1 = CurriculumModel.allCurriculum[techniqueTwo_picker.SelectedIndex].name;
                if (techniqueThree_picker.SelectedIndex != -1)
                    lesson.curriculum2 = CurriculumModel.allCurriculum[techniqueThree_picker.SelectedIndex].name;

                //Convert Lesson to DB Model
                var newLesson = buildLesson(lesson);

                // If they are checking into the same lesson just update the attendance roster. 
                if(newLesson.curriculum_id == GambitLessonModel.LatestLesson.curriculum_id &&
                    newLesson.curriculum1_id == GambitLessonModel.LatestLesson.curriculum1_id &&
                    newLesson.curriculum2_id == GambitLessonModel.LatestLesson.curriculum2_id)
                {
                    //Use latestLesson

                }
                //else, create a new lesson. Check them into that lesson. 

            }
            else
            {
                techniqueOne_picker.BackgroundColor = Color.Red;
            }
            
        }

        GambitLessonModel buildLesson(LessonModel lesson)
        {
            var gLesson = new GambitLessonModel();

            gLesson.curriculum_id = CurriculumModel.allCurriculum.Find(l => l.name == lesson.curriculum).id;

            if (techniqueTwo_picker.SelectedIndex != -1)
                gLesson.curriculum1_id = CurriculumModel.allCurriculum.Find(l => l.name == lesson.curriculum1).id;

            if (techniqueThree_picker.SelectedIndex != -1)
                gLesson.curriculum2_id = CurriculumModel.allCurriculum.Find(l => l.name == lesson.curriculum2).id;


            return gLesson;
        }

    }
}
