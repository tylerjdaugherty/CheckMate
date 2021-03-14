using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ZenWay.Models;

namespace CheckMate.ViewModels
{
    public class CheckinViewModel : INotifyPropertyChanged
    {
        public List<CurriculumModel> curriculm { get; set; } = CurriculumModel.allCurriculum;

        public string techniqueOne { get; set; }

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

        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
