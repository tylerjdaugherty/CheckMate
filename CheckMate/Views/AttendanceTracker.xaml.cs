using System;
using System.Collections.Generic;
using CheckMate.ViewModels;
using Xamarin.Forms;

namespace CheckMate.Views
{
    public partial class AttendanceTracker : ContentPage
    {
        public AttendanceTracker()
        {
            InitializeComponent();
            AttendanceTrackerViewModel atvm = new AttendanceTrackerViewModel();
            
        }
    }
}
