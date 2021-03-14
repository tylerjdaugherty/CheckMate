using Xamarin.Forms;
using CheckMate.ViewModels;

namespace CheckMate
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();


            BindingContext = new AttendanceTrackerViewModel();
            
        }

        
    }
}
