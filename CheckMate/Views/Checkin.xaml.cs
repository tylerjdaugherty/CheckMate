using System;
using System.Collections.Generic;
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

                lesson.curriculum = CurriculumModel.allCurriculum[techniqueOne_picker.SelectedIndex].name;
                if (techniqueTwo_picker.SelectedIndex != -1)
                    lesson.curriculum1 = CurriculumModel.allCurriculum[techniqueTwo_picker.SelectedIndex].name;
                if (techniqueThree_picker.SelectedIndex != -1)
                    lesson.curriculum2 = CurriculumModel.allCurriculum[techniqueThree_picker.SelectedIndex].name;
            }
            else
            {
                techniqueOne_picker.BackgroundColor = Color.Red;
            }




        }

    }
}
