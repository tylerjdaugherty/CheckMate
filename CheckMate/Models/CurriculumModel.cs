﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ZenWay.Models
{
    public class CurriculumModel
    {
        public CurriculumModel() { }

        public int id { get; set; }
        public string name { get; set; }

        public static List<CurriculumModel> allCurriculum = new List<CurriculumModel>();
    }

    
}
