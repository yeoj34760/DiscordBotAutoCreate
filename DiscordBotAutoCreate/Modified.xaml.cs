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
        public string temp;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Json.command[temp] = B_TextBox.Text;
            File.WriteAllText(Json.BotSettingpath, Json.command.ToString());
            Main.ListBoxLoad();
            Main.Show();
            Close();
        }
    }
}
