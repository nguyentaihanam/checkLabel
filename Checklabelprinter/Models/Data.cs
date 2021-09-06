using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklabelprinter.Models
{
    class Data
    {
        public String id { get; set; }
        public String printer_mac { get; set; }
        public String username { get; set; }
        public String upload_at { get; set; }
        public String check_at { get; set; }
        public String[] image_links { get; set; }
        public String Checked { get; set; }
        public String expired { get; set; }
        public String accepted { get; set; }
    }
}
