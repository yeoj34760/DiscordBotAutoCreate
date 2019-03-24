using Newtonsoft.Json.Linq;
using System.IO;

public class Json
{
    public static string BotSettingpath = $@"{Program.Path}\Bot\BotSetting.json";
    public static JObject rss = JObject.Parse(File.ReadAllText($@"{Program.Path}\Bot\BotSetting.json")), command = rss["command"] as JObject;//불러온 파일을 파싱을 합니다.
}
public class Program
{
    public static string Path = Directory.GetCurrentDirectory();
}