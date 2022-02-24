using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenshinWish
{
    public partial class Form1 : Form
    {
        string version = "v0.2";
        public Form1()
        {
            InitializeComponent();
            lblVer.Text = version;
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            string fileName = @"%userprofile%\AppData\LocalLow\miHoYo\Genshin Impact\output_log.txt";
            String file = Environment.ExpandEnvironmentVariables(fileName);

            FileInfo log = new FileInfo(file);
            using (var sr = new StreamReader(log.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string text = sr.ReadToEnd();
                string findLink = @"OnGetWebViewPageFinish:https://webstatic-sea.mihoyo.com/";
                string findLog = @"#/log";

                int lenLink = findLink.Length;
                int lenLog = findLog.Length;

                try
                {
                    string linkBuffer = text.Substring(text.IndexOf(findLink), text.Length - text.IndexOf(findLink));
                    string link = linkBuffer.Substring(linkBuffer.IndexOf(findLink), linkBuffer.IndexOf(findLog) - linkBuffer.IndexOf(findLink) + lenLog + lenLink);
                    link = link.Replace("OnGetWebViewPageFinish:", "");
                    link = link.Substring(0, link.IndexOf(findLog) + lenLog);
                    Clipboard.SetText(link);
                    MessageBox.Show("Ссылка скопирована!", "Успех!");
                }
                catch (Exception error)
                {
                    //Console.WriteLine(error.Message);
                    MessageBox.Show(String.Format("{0}", error.Message), "Ошибка!");
                }
                
            }
        }

    }
}
