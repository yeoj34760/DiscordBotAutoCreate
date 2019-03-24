using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscordBotAutoCreate
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            answerLabel.Content = null;
            ListBoxLoad();
        }

        public void ListBoxLoad()
        {

            CommandLlistBox.Items.Clear();
            foreach (var item in Json.command) CommandLlistBox.Items.Add(item.Key);
            CommandLlistBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var Add = new AddWindow();
            Add.Show();
            Close();
        }

        private void DeleButton_Click(object sender, RoutedEventArgs e)
        {
            Json.command.Property(CommandLlistBox.SelectedItem.ToString()).Remove();
            File.WriteAllText(Json.BotSettingpath, Json.rss.ToString());
            ListBoxLoad();
        }

        private void ModifiedButton_Click(object sender, RoutedEventArgs e)
        {
            var Mod = new Modified();

            Mod.B_name = CommandLlistBox.SelectedItem.ToString();
            Mod.Title = Mod.B_name;

            Mod.B_CheckBox.IsChecked = (Json.command[CommandLlistBox.SelectedItem.ToString()]["PLUS"].ToString() == "True") ? true : false;
            Mod.B_TextBox.Text = Json.command[CommandLlistBox.SelectedItem.ToString()]["answer"].ToString();
            Mod.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Hide();// 폼숨김
            Process bot = new Process();
            bot.StartInfo.CreateNoWindow = true;
            bot = Process.Start("py.exe", $@"{Program.Path}\Bot\Start.py");
            bot.WaitForExit(); //종료될시 폼표시
            Show();

        }
        private void CommandLlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string temp = (Json.rss["token"].ToString() == "") ? "없음" : Json.rss["token"].ToString(); //삼항연산자
                answerLabel.Content = $"토큰 : {temp}\n내용 : {Json.command[CommandLlistBox.SelectedItem.ToString()]["answer"].ToString()} \n은?/는? 자동화 : {Json.command[CommandLlistBox.SelectedItem.ToString()]["PLUS"].ToString()}";
            }
            catch (SystemException) { } //예외처리 ㅎ
        }

        private void TokenButton_Click(object sender, RoutedEventArgs e)
        {
            var token = new TokenWindow();
            token.Show();
            Close();
        }
    }
}
