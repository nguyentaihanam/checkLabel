using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklabelprinter.Utils
{
    class Log
    {
        public static void e(String error)
        {
            try
            {
                String Date = DateTime.Now.ToString("yyyy.MM.dd");
                using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\Log\\" + Date, true))
                {
                    String message = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - ERROR - " + error;
                    writer.WriteLine(message);
                }
            }
            catch
            {

            }
           
        }
        public static void i(String info)
        {
            String Date = DateTime.Now.ToString("yyyy.MM.dd");
            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\Log\\" + Date, true)) 
            {
                String message = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - INFO - " + info;
                writer.WriteLine(message);
            }
        }

        public static void w(String warm)
        {
            String Date = DateTime.Now.ToString("yyyy.MM.dd");
            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\Log\\" + Date, true))
            {
                String message = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - WARM - " + warm;
                writer.WriteLine(message);
            }
        }
    }
}
