using Checklabelprinter.Bases;
using Checklabelprinter.Models;
using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Checklabelprinter.Controllers
{
    class PostDatatoServer
    {
        public void SendDataLabel(string info)
        {
            string URL = Constants.urlLabel;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["x-access-token"] = Constants.token;

            try
            {
                var request = httpWebRequest.GetRequestStream();
                using (var streamWriter = new StreamWriter(request))
                {
                    var jsonImage = new JavaScriptSerializer().Serialize(info);
                    streamWriter.Write(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderImage = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReaderImage.ReadToEnd();
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    var routes_list = json_serializer.Deserialize<JsonResponse>(result);
                    Console.WriteLine(result.Trim());
                }
            }

            else
            {

            }

        }
    }
}
