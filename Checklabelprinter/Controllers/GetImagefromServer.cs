using Checklabelprinter.Bases;
using Checklabelprinter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Checklabelprinter.Controllers
{
    class GetImagefromServer
    {
        
        public List<DataProcess> GetDataFromServer()
        {
            List<DataProcess> dataLabels = new List<DataProcess>();
            int count = 10;
            string URL = Constants.url;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers["x-access-token"] = Constants.token;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderImage = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReaderImage.ReadToEnd();

                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    var routes_list = json_serializer.Deserialize<JsonResponseServer>(result);
                    JsonData dataTotal = routes_list.data;
                    Data[] datas = dataTotal.data;
                    if(datas.Length < count)
                    {
                        foreach(Data data in datas)
                        {
                            DataProcess dataLabel = new DataProcess();
                            dataLabel.id = data.id;
                            dataLabel.image_links = data.image_links;
                            dataLabels.Add(dataLabel);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            DataProcess dataLabel = new DataProcess();
                            dataLabel.id = datas[i].id;
                            dataLabel.image_links = datas[i].image_links;
                            dataLabels.Add(dataLabel);
                        }
                    }
                }
            }

            else
            {
                
            }
            Console.WriteLine(dataLabels.ToString());
            return dataLabels;
        }
    }
}
