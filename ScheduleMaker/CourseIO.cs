using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScheduleMaker
{
    internal class CourseIO {
        string Path { get; set; }
        FileStream fs { get; set; }
        public string filestring { get; set; }
        public bool Failed { get; set; }


        public CourseIO(string Given_Path) {
            Path = Given_Path;
            if (!File.Exists(Path)) {

                if (!CreateFile()) {
                    Failed = true;
                }
            }
            else {
                if (!OpenFile()) {
                    Failed = true;
                }
            }
            byte[] buffer = new byte[(int) fs.Length];
            fs.Read(buffer, 0, (int) fs.Length);
            filestring = Encoding.ASCII.GetString(buffer);


        }

        public void CleanUp() {
            fs.Close();
        }
        public void WriteFile() {
            fs.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[filestring.Length];
            buffer = ASCIIEncoding.ASCII.GetBytes(filestring);
            fs.Write(buffer, 0, buffer.Length);
        }
        // Creates a file, checking success
        private bool CreateFile()
        {
            bool success = true;
            fs = new FileStream(Path, FileMode.Create);

            return success;
        }

        // Opens File, if already existant
        private bool OpenFile() {
            bool success = true;
            fs = new FileStream(Path, FileMode.Open);

            return success;
        }
    }
}
