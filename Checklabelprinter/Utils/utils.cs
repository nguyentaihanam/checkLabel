using Checklabelprinter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Checklabelprinter.Utils
{
    class utils
    {
        public static string read_xml(string path, string heading)
        {
            XDocument doc = XDocument.Load(path);
            var results = doc.Descendants(heading);
            foreach (var result in results)
            {

                return result.Value;
            }
            return "no" + heading;
        }

        public static void CheckFolder()
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Log\\"))
                {
                    Console.WriteLine("That path exists already.");
                }
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Log\\");
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(Directory.GetCurrentDirectory() + "\\Log\\"));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static string ConvertJson(string id, bool accepted)
        {
            var objPost = new JsonPrinter
            {
                image_id = id,
                accepted = accepted,
            };

            var jsonImage = new JavaScriptSerializer().Serialize(objPost);
            return jsonImage;
        }
    }
}
