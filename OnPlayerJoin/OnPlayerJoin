using System;
using Microsoft.Xna.Framework;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace OnPlayerJoin
{
    [ApiVersion(2, 1)]
    public class OnPlayerJoin : TerrariaPlugin
    {
        public override string Name => "OnPlayerJoin";
        public override Version Version => new Version(1, 0, 0);
        public override string Author => "Melton";
        public override string Description => "Custom join and leave message";

        private Config config = null!;

        public OnPlayerJoin(Main game) : base(game)
        {
            Order = 676767;
        }

        public override void Initialize()
        {
            config = Config.Reload();

            ServerApi.Hooks.NetGreetPlayer.Register(this, OnGreetPlayer);
            ServerApi.Hooks.ServerLeave.Register(this, OnLeavePlayer);
        }

        private void OnGreetPlayer(GreetPlayerEventArgs args)
        {
            if (!config.Enable)
                return;

            TSPlayer player = TShock.Players[args.Who];
            if (player == null || !config.JoinSettings.EnableJoinMessage)
                return;

            player.SilentJoinInProgress = true;

            string message = config.JoinSettings.Join;
            string formatted;

            try
            {
                formatted = string.Format(message, player.Name);
            }
            catch
            {
                formatted = player.Name;
            }

            TShock.Utils.Broadcast(formatted, Color.White); // Join Message
        }

        private void OnLeavePlayer(LeaveEventArgs args)
        {
            if (!config.Enable)
                return;

            TSPlayer player = TShock.Players[args.Who];
            if (player == null || !config.JoinSettings.EnableLeaveMessage)
                return;

            player.SilentKickInProgress = true;

            string message = config.JoinSettings.Left;
            string formatted;

            try
            {
                formatted = string.Format(message, player.Name);
            }
            catch
            {
                formatted = player.Name;
            }

            TShock.Utils.Broadcast(formatted, Color.White); // Left Message
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.NetGreetPlayer.Deregister(this, OnGreetPlayer);
                ServerApi.Hooks.ServerLeave.Deregister(this, OnLeavePlayer);
            }
            base.Dispose(disposing);
        }
    }
}
