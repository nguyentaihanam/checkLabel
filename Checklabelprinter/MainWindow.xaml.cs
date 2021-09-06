using Checklabelprinter.Bases;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using SimpleCode;
using System.Diagnostics;
using Checklabelprinter.Controllers;
using Checklabelprinter.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using Checklabelprinter.Utils;
using System.Web.Script.Serialization;

namespace Checklabelprinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();         
        }

        GetImagefromServer image = new GetImagefromServer();
        GetDataImage dataImage = new GetDataImage();
        CheckCodeQuality myCheck = new CheckCodeQuality();
        PostDatatoServer dataLabel = new PostDatatoServer();

        public static GuiLogger _logger;
        private bool _closing = false;
        private bool isCheck = false;
        Thread m_threadData = null;

        System.Timers.Timer timerCheckList;

        List<string> jsontoserver = new List<string>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _logger = new GuiLogger(txt_log, true , ref _closing);
            utils.CheckFolder();
            timerCheckList = new System.Timers.Timer(1000);
            TimerCheckList();
        }

        public void TimerCheckList()
        {
            timerCheckList.Elapsed += CheckListDevice;
            timerCheckList.AutoReset = true;
            timerCheckList.Enabled = true;
        }
        int count = 0;
        public void CheckListDevice(Object source, ElapsedEventArgs e)
        {
            
            if (!isCheck)
            {
                count++;
                Console.WriteLine("chay den day" + count.ToString());
                isCheck = true;
                m_threadData = new Thread(() => { Threadprocess(); });
                m_threadData.Start();
            }    
        }

        public void Threadprocess()
        { 
            List<DataProcess> listData = image.GetDataFromServer();
            if(listData.Count != 0)
            {
                for (int i = 0; i < listData.Count; i++)
                {
                    bool _isPrinter = isPrinter(listData[i]);
                    Log("Data:", listData[i].image_links.ToString() + " " + _isPrinter);
                    Utils.Log.i(listData[i].image_links.ToString() + " " + _isPrinter);
                    jsontoserver.Add(utils.ConvertJson(listData[i].id, _isPrinter));

                }

                string[] array = jsontoserver.ToArray();

                string a = "[" + string.Join(",", array) + "]";

                dataLabel.SendDataLabel(a);

                if (m_threadData.IsAlive)
                {
                    m_threadData.Interrupt();
                }
                
            }
            isCheck = false;
        }
        

        private bool isPrinter (DataProcess printer)
        {
            bool isCheck = false;
            foreach (string path in printer.image_links)
            {
                Bitmap image = dataImage.GetData(path);
                // chay job o day
                myCheck.Run(image);
                string Result = myCheck.Result;
                double quality = myCheck.OverallGrade;
                double deco = myCheck.DecodabilityValue;
                double deco1 = myCheck.DecodabilityGrade;

                Utils.Log.i(path + " " + " result:" + Result + " quality:" + quality + " deco:" + deco + " deco1:" + deco1);
                if (quality >= 0.2 || Result != "NoRead")
                {
                    isCheck = true;
                    break;
                }
            }

            return isCheck;
        }

        #region write log in form
        public static void Log(string function, string message)
        {
            if (_logger != null)
                _logger.Log(function, message);
        }

        public static void Log_line(string message)
        {
            if (_logger != null)
                _logger.Log_line(message);
        }
        #endregion

        private void txt_log_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txt_log.ScrollToEnd();
        }
    }
}
