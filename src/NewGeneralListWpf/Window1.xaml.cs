using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewGeneralListWpf
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        private string ngsl_file = String.Empty;
        private string ngsl_pfile = String.Empty;
        public Window1()
        {
            InitializeComponent();
        }

        private void btn_selectfile_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            btn_convert.IsEnabled = false;
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Environment.CurrentDirectory.ToString() };
            if (ofd.ShowDialog() == true)
            {
                if (button.Name == "btn_selectfilengsl")
                {
                    ngsl_file = ofd.FileName;
                    txt_ngsl_full.Text = LoadNGSL(ngsl_file);
                }
                else if (button.Name == "btn_selectfilengsl_p")
                {
                    ngsl_pfile = ofd.FileName;
                    txt_ngsl_p.Text = LoadNGSL(ngsl_pfile);
                }
            }
            btn_convert.IsEnabled = true;
        }

        private void btn_convert_Click(object sender, RoutedEventArgs e)
        {
            List<string> listfull = new NGSL.NewGeneralServiceList(ngsl_file).Words;
            List<string> listp = new NGSL.NewGeneralServiceList(ngsl_pfile).Words;
            List<String> listwithoutp = new List<string> { };
            foreach (string s in listfull)
            {

                //2.use List Except
                listwithoutp = listfull.Except<string>(listp).ToList();

            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in listwithoutp)
            {
                sb.AppendLine(s);
            }
            txt_ngsl_withoutp.Text = sb.ToString().TrimEnd();

            txt_ngsl_full.Background = txt_ngsl_p.Background = txt_ngsl_withoutp.Background = Brushes.LightYellow;

            lab_ngsl_full.Text = "NGSL FUll:" + listfull.Count;
            lab_ngsl_p.Text = "NGSL-Spoken:" + listp.Count;
            lab_ngsl_withoutp.Foreground = Brushes.Red;
            lab_ngsl_withoutp.Text = $"NGSL Without Spoken:{listwithoutp.Count}(truly:{listfull.Count - listp.Count}),error!";
        }
        private string LoadNGSL(string filename)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filename))
            {
                sb.Append(sr.ReadToEnd());
            }
            return sb.ToString();
        }
    }
}
