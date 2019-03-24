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

namespace DiscordBotAutoCreate
{
    /// <summary>
    /// Modified.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Modified : Window
    {
        
        public Modified()
        {
            InitializeComponent();
        }
        public string B_name;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            
            Json.command[B_name]["answer"] = B_TextBox.Text;
            Json.command[B_name]["PLUS"] = B_CheckBox.IsChecked;
            File.WriteAllText(Json.BotSettingpath, Json.rss.ToString());
            Main.ListBoxLoad();
            Main.Show();
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
