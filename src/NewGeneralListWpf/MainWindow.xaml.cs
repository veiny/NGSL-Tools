using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewGeneralListWpf.NGSL;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;

namespace NewGeneralListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filestring = string.Empty;
        private NewGeneralServiceList? ngsl;
        private NGSLEntity? entity;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_selectfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Environment.CurrentDirectory.ToString() };
            if (ofd.ShowDialog() == true)
            {
                tb_filestring.Text = filestring = ofd.FileName;
            }
            btn_demorun.IsEnabled = true;
        }

        private void btn_demorun_Click(object sender, RoutedEventArgs e)
        {
            //example 1
            //ngsl ??= new NewGeneralServiceList(filestring);
            //string word = ngsl.AnyOneWord();

            //example 2
            entity ??= new NGSLEntity(NGSLKind.NGSL_FULL);
            string word = entity.AnyWord();
            containter.Children.Add(BuildWordsCard(word));
        }
        private UIElement BuildWordsCard(string text)
        {
            Grid grid = new Grid() { Height = 100, Width = 100, Margin = new Thickness(2) };
            TextBlock tb = new TextBlock()
            {
                Text = text,
                FontSize = 15,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Rectangle rect = new Rectangle() { Fill = Brushes.SteelBlue };
            grid.Children.Add(rect);
            grid.Children.Add(tb);
            return grid;
        }

        private void btn_tool_click(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
        }
    }
}
