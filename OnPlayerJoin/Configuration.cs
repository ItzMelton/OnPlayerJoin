using Newtonsoft.Json;
using TShockAPI;

namespace OnPlayerJoin
{
    public class Config
    {
        public bool Enable = true;
        public JoinMessageConfig JoinSettings = new JoinMessageConfig();
        
        public Dictionary<string, string> HelpFormat = new Dictionary<string, string>
        { // Help Format
            { "{0}", "PlayerName" }
            // MORE COMING SOON
        };

        public void Write()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static Config Reload() // Reload Config
        {
            Config? c = null;

            if (File.Exists(ConfigPath))
                c = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));

            c ??= new Config();

            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(c, Formatting.Indented));

            return c;
        }

        public static string ConfigPath => Path.Combine(TShock.SavePath, "PlayerJoinConfig.json");
    }
    
    public class JoinMessageConfig
    { // Default Msgs & Booleans
        public bool EnableJoinMessage = true;
        public bool EnableLeaveMessage = true;
        public string Join = "{0} has joined the server!";
        public string Left = "{0} has left the server!";
    }
}
