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
    /// TokenWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TokenWindow : Window
    {
        public TokenWindow()
        {
            InitializeComponent();
            TokenTextBox.Text = Json.rss["token"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Json.rss["token"] = TokenTextBox.Text;
            File.WriteAllText(Json.BotSettingpath, Json.rss.ToString());
            var Main = new MainWindow();
            Main.Show();
            Close();
        }
    }
}
