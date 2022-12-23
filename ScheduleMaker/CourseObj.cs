using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker {
    internal class Courses {
        public List<CourseObj> courses { get; set; }
        public void InsertCourse(CourseObj To_Insert) {
            courses.Add(To_Insert);
        }

    }

    internal class CourseObj {
        public string Name { get; set; }
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
