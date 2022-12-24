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
            CourseIO input = new CourseIO();
            input.OpenClassList("Classes/2023/Spring/ECE.json");

            Courses CJson = new Courses { courses = new List<CourseObj> { }, Path = input.Path, CourseProgram = "ECE"};

            
            string to_add = JsonConvert.SerializeObject(CJson);
            input.filestring = to_add;
            input.WriteFile();
            input.CleanUp();


        }
    }
}
