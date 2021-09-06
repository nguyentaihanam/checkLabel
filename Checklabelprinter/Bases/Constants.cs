using Checklabelprinter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklabelprinter.Bases
{
    class Constants
    {
        public static readonly string filechange = utils.read_xml(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Xray\\setcheck.xml", "filechange");
        public static readonly string filter = utils.read_xml(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Xray\\setcheck.xml", "filter");
        public static readonly string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFwcG5vaWJvIiwidXNlcl9pZCI6IjVjMzg1ODU0ZDE5N2EzMGQzOTE0YTUxNCIsIm5hbWUiOiJIYXJkIFRva2VuIGTDuW5nIGNobyBhcHAgbuG7mWkgYuG7mSIsInN0YXR1cyI6InZlcmlmaWVkIiwiaWF0IjoxNjE0OTM4NzA5fQ.-NJ15sTd4rCO5l-jfazO_Qx93z5y2YHwyL_XHHUuT_o";
        /*public static readonly string token = "mCkA34oMf1YpK2hk5rgRMpxk2CiycrWH";*/
        /*public static readonly string url = "https://iot.ghtklab.com/device/printer/printer-images?page=1&size100";*/
        public static readonly string url = "https://iot.ghtk.vn/device/printer/printer-images?page=1&size100";
        public static readonly string urlLabel = "https://iot.ghtk.vn/device/printer/printer-image-checks";
    }
}
