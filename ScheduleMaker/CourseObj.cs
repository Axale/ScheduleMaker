using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker {
    internal class Courses {
        public List<CourseObj> courses { get; set; }
        public string CourseProgram;
        public string CourseDir;
        public void InsertCourse(CourseObj To_Insert) {
            courses.Add(To_Insert);
        }

        public CourseObj FindCourse(string CourseNum) {
            CourseObj To_Return = null;
            for(int i = 0; i < courses.Count; i++) {
                if(CourseNum == courses[i].CourseNum) {
                    To_Return = courses[i];
                }
            }

            return To_Return;
        }


    }

    internal class CourseObj {
        public string CourseNum { get; set; }
        public int CreditHours { get; set; }
        public int NumberOfMeetings { get; set; }
        public List<MeetingTime> MeetingList { get; set; }

        public class MeetingTime {
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string Day { get; set; }
            public string Type { get; set; }

        }
    }
}
