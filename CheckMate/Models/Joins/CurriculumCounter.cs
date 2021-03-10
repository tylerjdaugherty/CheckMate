using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZenWay.Models;

namespace CheckMate.Models.Joins
{
    public class CurriculumCounter : CurriculumModel
    {
        public int count { get; set; } = 0;
        public int need { get; set; } = 4; 

        public CurriculumCounter()
        {
           
        }

    }
}
