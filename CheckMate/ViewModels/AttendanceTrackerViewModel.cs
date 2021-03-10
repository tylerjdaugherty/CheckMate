using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZenWay.Models;

namespace CheckMate.ViewModels
{
    public class AttendanceTrackerViewModel
    {
        List<CurriculumModel> count = new List<CurriculumModel>();

        //Curriculum Sample


        public AttendanceTrackerViewModel()
        {
            string json = "{id : 1, Name : 'Take Downs'}";
            CurriculumModel cm = JsonConvert.DeserializeObject<CurriculumModel>(json);

        }
    }
}
