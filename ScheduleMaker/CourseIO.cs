using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScheduleMaker
{
    internal class CourseIO {
        string Path;
        FileStream fs;
        string filestring;
        public bool Failed;


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

        }

        // Creates a file, checking success
        private bool CreateFile()
        {
            bool success = true;
            try { 
                fs = new FileStream(Path, FileMode.Create);
            } catch (IOException) {
                success = false;
            } finally {
                if(!success)
                {
                    fs.Close();
                }
            }

            return success;
        }

        private bool OpenFile() {
            bool success = true;
            try {
                fs = new FileStream(Path, FileMode.Open);
            }
            catch (IOException) {
                success = false;
            } finally {
                if(!success) {
                    fs.Close();
                }
            }

            return success;
        }
    }
}
