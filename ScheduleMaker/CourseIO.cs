using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScheduleMaker
{
    internal class CourseIO {
        public string Path { get; set; }
        public string filedir { get; set; }
        FileStream fs { get; set; }
        public string filestring { get; set; }
        public bool Failed { get; set; }


        public bool OpenClassList(string Given_Path) {
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

            if(Failed) {
                return false;
            }
            byte[] buffer = new byte[(int) fs.Length];
            fs.Read(buffer, 0, (int) fs.Length);
            filestring = Encoding.ASCII.GetString(buffer);

            return true;
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
            int dirlen;
            for (dirlen = Path.Length - 1; dirlen > 0 && Path[dirlen] != '/'; dirlen--) {
            }
            string filedir = Path.Substring(0, dirlen);
            try {
                Directory.CreateDirectory(filedir);
                fs = new FileStream(Path, FileMode.Create);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        // Opens File, if already existant
        private bool OpenFile() {
            try {
                fs = new FileStream(Path, FileMode.Open);
            }
            catch (Exception) {
                return false;
            }


            return true;
        }
    }
}
