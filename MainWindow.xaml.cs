using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Weather2
{
    public partial class MainWindow : Window
    {
        string logDirPath = ReadValue("PATH", "LOG_DIR");
        string dataFilePath = ReadValue("PATH", "DATA_FILE");
        string data = "";
        FileStream fs = null;
        StreamWriter sw = null;

        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        public static string ReadValue(string section, string key)
        {
            StringBuilder tmp = new StringBuilder(255);

            GetPrivateProfileString(section, key, string.Empty, tmp, 255, ".\\Weather2.ini");

            return tmp.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();

            if (!Directory.Exists(logDirPath))
                Directory.CreateDirectory(logDirPath);

            Top = Convert.ToDouble(ReadValue("POS", "TOP"));
            Left = Convert.ToDouble(ReadValue("POS", "LEFT"));
            Cursor = System.Windows.Input.Cursors.None;

            GetTime();
            GetTemp();

            Timer TimeTimer = new Timer();
            TimeTimer.Interval = 1000; // 1초
            TimeTimer.Tick += ShowTime;
            TimeTimer.Start();

            Timer TempTimer = new Timer();
            TempTimer.Interval = 120000; // 120초
            TempTimer.Tick += ShowTemp;
            TempTimer.Start();
        }

        private void ShowTime(object sender, EventArgs e)
        {
            GetTime();
        }

        private void ShowTemp(object sender, EventArgs e)
        {
            GetTemp();
        }

        private void GetTime()
        {
            Date.Text = DateTime.Now.ToString("M월 d일");
            Time.Text = DateTime.Now.ToString("HH:mm");
        }

        private void GetTemp()
        {
            data = "";

            try
            {
                using (WebClient client = new NoKeepAliveWebClient())
                {
                    data = Encoding.UTF8.GetString(client.DownloadData(dataFilePath));
                    //data = File.ReadAllText(dataFilePath); // 로컬 경로일 때
                }
            }
            catch (Exception ex)
            {
                SaveLog(ex.ToString());
            }

            Temp.Text = data;

            SaveLog("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + Date.Text + " / " + Time.Text + " / " + Temp.Text);
        }

        public void SaveLog(string msg)
        {
            fs = null;
            sw = null;

            try
            {
                fs = new FileStream(logDirPath + "\\Weather2_log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.Append);

                sw = new StreamWriter(fs);
                sw.WriteLine(msg);

                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                if (sw != null)
                    sw.Close();

                if (fs != null)
                    fs.Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
