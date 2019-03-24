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
using Newtonsoft.Json.Linq;
namespace DiscordBotAutoCreate
{
    /// <summary>
    /// AddWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var Main = new MainWindow();
            Json.command.Add(QTextbox.Text, new JObject(
                new JProperty("answer", ATextbox.Text),
                new JProperty("PLUS", B_Check.IsChecked)));
            File.WriteAllText(Json.BotSettingpath, Json.command.ToString());
            Main.ListBoxLoad();
            Main.Show();
            Close();
        }

        private void QTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
