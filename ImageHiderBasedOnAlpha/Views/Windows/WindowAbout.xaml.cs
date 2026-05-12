using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageHiderBasedOnAlpha.Views.Windows
{
    /// <summary>
    /// WindowAbout.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAbout : Window
    {
        public WindowAbout()
        {
            InitializeComponent();
        }

        //EXIT
        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        //链接跳转
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
            => Process.Start(new ProcessStartInfo
            {
                FileName = ((Hyperlink)sender).NavigateUri.ToString(),
                UseShellExecute = true
            });
    }
}
