using System;
using Newtonsoft.Json.Linq;

namespace CheckMate.Models
{
    public class GambitLessonModel
    {
        public GambitLessonModel()
        {
        }

        public int lesson_id { get; set; }
        public string date { get; set; }
        public bool private_lesson { get; set; } = false;
        public int? curriculum_id { get; set; }
        public int? curriculum1_id { get; set; } = 0;
        public int? curriculum2_id { get; set; } = 0;
        public int? technique_id { get; set; } = 0;
        public int? technique1_id { get; set; } = 0;
        public int? technique2_id { get; set; } = 0;
        public int? technique3_id { get; set; } = 0;
        public int? technique4_id { get; set; } = 0;
        public int? technique5_id { get; set; } = 0;

        static public GambitLessonModel LatestLesson { get; set; }

        static public GambitLessonModel buildLesson(JObject lesson)
        {
            GambitLessonModel gLesson = new GambitLessonModel();

            gLesson.lesson_id = (int)lesson["lesson_id"];
            gLesson.date = (string)lesson["date"];
            gLesson.private_lesson = (bool)lesson["private_lesson"];
            gLesson.curriculum_id = (int)lesson["curriculum_id"];
            
            gLesson.curriculum1_id = ((int)lesson["curriculum1_id"] >= 0) ? (int)lesson["curriculum1_id"] : -1;
            gLesson.curriculum2_id = ((int)lesson["curriculum2_id"] >= 0) ? (int)lesson["curriculum2_id"] : -1;
            gLesson.technique1_id = ((int)lesson["technique1_id"] >= 0) ? (int)lesson["technique1_id"] : -1;
            gLesson.technique2_id = ((int)lesson["technique2_id"] >= 0) ? (int)lesson["technique2_id"] : -1;
            gLesson.technique3_id = ((int)lesson["technique3_id"] >= 0) ? (int)lesson["technique3_id"] : -1;
            gLesson.technique4_id = ((int)lesson["technique4_id"] >= 0) ? (int)lesson["technique4_id"] : -1;
            gLesson.technique5_id = ((int)lesson["technique5_id"] >= 0) ? (int)lesson["technique5_id"] : -1;

            return gLesson;
        }
    }
}
