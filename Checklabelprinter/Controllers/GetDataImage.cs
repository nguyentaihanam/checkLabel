using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checklabelprinter.Controllers
{
    class GetDataImage
    {
        public Bitmap GetData(string url)
        { 
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            Bitmap bitmap = new Bitmap(stream);

            /*Image image = (Image)bitmap;
            image.Save("haha.jpg");*/

            /*if (bitmap != null)
            {
                bitmap.Save("oke.jpg", ImageFormat.Jpeg);
            }*/

            stream.Flush();
            stream.Close();
            client.Dispose();
            return bitmap;
        }
    }
}
