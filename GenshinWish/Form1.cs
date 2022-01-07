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
        string version = "v0.1";
        public Form1()
        {
            InitializeComponent();
            lblVer.Text = version;
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            string fileName = @"%USERPROFILE%\AppData\LocalLow\miHoYo\Genshin Impact\output_log.txt";
            String file = Environment.ExpandEnvironmentVariables(fileName);

            FileInfo log = new FileInfo(file);
            using (var sr = new StreamReader(log.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string text = sr.ReadToEnd();
                string findLink = @"OnGetWebViewPageFinish:https://webstatic-sea.mihoyo.com/";
                string findLog = @"#/log";

                int lenLink = findLink.Length;
                try
                {
                    string link = text.Substring(text.IndexOf(findLink), text.IndexOf(findLog) - text.IndexOf(findLink) + findLog.Length + findLink.Length);
                    link = link.Replace("OnGetWebViewPageFinish:", "");
                    link = link.Substring(0, link.IndexOf(findLog) + findLog.Length);
                    Clipboard.SetText(link);
                    MessageBox.Show("Ссылка скопирована!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ссылки нет!");
                }
                
            }
        }

    }
}
