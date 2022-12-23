using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ScheduleMaker
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
            CourseIO input = new CourseIO("../../json/courses.json");
            Courses CJson = new Courses { courses = new List<CourseObj> { } };
            CourseObj courseObj = new CourseObj {
                CreditHours = 1,
                Name = "ECE 20002",
                NumberOfMeetings = 1,
            };
            courseObj.MeetingList = new List<CourseObj.MeetingTime>(courseObj.CreditHours);
            courseObj.MeetingList.Add(new CourseObj.MeetingTime { Day = "R", StartTime = "12:30", EndTime = "14:20", Type = "Lab" });
            CJson.InsertCourse(courseObj);
            string to_add = JsonConvert.SerializeObject(CJson);
            input.filestring = to_add;
            input.WriteFile();
            input.CleanUp();


        }
    }
}
