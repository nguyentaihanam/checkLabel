using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklabelprinter.Models
{
    class JsonResponseServer
    {
        public String success { get; set; }
        public JsonData data { get; set; }
        public String message { get; set; }
    }
}
