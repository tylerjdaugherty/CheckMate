using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenWay.Models
{
    public class LessonModel
    { 
        public int lesson_id { get; set; }
        public string date { get; set; }
        public bool private_lesson { get; set; } = false;
        public string curriculum { get; set; }
        public string curriculum1 { get; set; }
        public string curriculum2 { get; set; }

        
    }
}
