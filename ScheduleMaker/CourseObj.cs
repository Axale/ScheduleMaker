using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker {
    internal class CourseObj {
        public string Name;
        public string CreditHours;
        public string NumberOfMeetings;
        public List<MeetingTime> MeetingTimes;

        public class MeetingTime {
            public string StartTime;
            public string EndTime;
            public string Type;

            public MeetingTime(string g_Start, string g_End, string g_Type) {
                StartTime = g_Start;
                EndTime = g_End;
                Type = g_Type;
            }
        }
    }
}
