using System;
using System.Collections.Generic;
using CheckMate.ViewModels;
using Xamarin.Forms;

namespace CheckMate.Views
{
    public partial class Checkin : ContentPage
    {
        public Checkin()
        {
            InitializeComponent();
            //this.BindingContext = CheckinViewModel;
        }

        async void checkInButton_Clicked(object sender, EventArgs args)
        {
            Console.WriteLine("Check In Clicked");
        }
        
    }
}
