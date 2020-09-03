using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using Rocket.Unturned.Events;
using SDG.Unturned;
using System;
using UnityEngine;

using Logger = Rocket.Core.Logging.Logger;

namespace F.KillFeed
{
    public class Main : RocketPlugin
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("F.KillFeed Loaded", ConsoleColor.Red);
            Logger.Log("Plugin Version 1.0", ConsoleColor.Red);
            Logger.Log("F.Plugins Discord: https://discord.gg/4FF2548", ConsoleColor.Yellow);

            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;
            U.Events.OnPlayerDisconnected -= OnPlayerDisconnected;
        }

        private void OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, Steamworks.CSteamID murderer)
        {
            if (cause.ToString() == "GUN")
            {
                if (limb == ELimb.SKULL)
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]</color> " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " <color=lime>[" + Math.Round((double)Vector3.Distance(player.Position, UnturnedPlayer.FromCSteamID(murderer).Position)).ToString() + "M] [HS]</color> " + player.DisplayName);
                }
                else if (limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_BACK || limb == ELimb.LEFT_FOOT || limb == ELimb.LEFT_FRONT || limb == ELimb.LEFT_HAND || limb == ELimb.LEFT_LEG || limb == ELimb.RIGHT_ARM || limb == ELimb.RIGHT_BACK || limb == ELimb.RIGHT_FOOT || limb == ELimb.RIGHT_FRONT || limb == ELimb.RIGHT_HAND || limb == ELimb.RIGHT_LEG || limb == ELimb.SPINE)
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]</color> " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " <color=lime>[" + Math.Round((double)Vector3.Distance(player.Position, UnturnedPlayer.FromCSteamID(murderer).Position)).ToString() + "M]</color> " + player.DisplayName);
                }
                else
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]</color> " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " <color=lime>[" + Math.Round((double)Vector3.Distance(player.Position, UnturnedPlayer.FromCSteamID(murderer).Position)).ToString() + "M]</color> " + player.DisplayName);
                }

            }
            else if (cause.ToString() == "MELEE")
            {
                if (limb == ELimb.SKULL)
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]</color> " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " [HS]</color> " + player.DisplayName);
                }
                else if (limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_BACK || limb == ELimb.LEFT_FOOT || limb == ELimb.LEFT_FRONT || limb == ELimb.LEFT_HAND || limb == ELimb.LEFT_LEG || limb == ELimb.RIGHT_ARM || limb == ELimb.RIGHT_BACK || limb == ELimb.RIGHT_FOOT || limb == ELimb.RIGHT_FRONT || limb == ELimb.RIGHT_HAND || limb == ELimb.RIGHT_LEG || limb == ELimb.SPINE)
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]</color>" + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " " + player.DisplayName);
                }
                else
                {
                    EffectManager.sendUIEffect(32479, 312, true, UnturnedPlayer.FromCSteamID(murderer).CharacterName + " <color=lime>[" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + " HP]" + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " " + player.DisplayName);
                }
            }
        }
        
        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= OnPlayerDeath;
            U.Events.OnPlayerDisconnected -= OnPlayerDisconnected;
        }
    }
}
