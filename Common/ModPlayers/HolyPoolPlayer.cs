using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Common.ModPlayers
{
    public class HolyPoolPlayer : ModPlayer
    {
        // Here we create a custom resource, similar to mana or health.
        // Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
        public int HolyPoolCurrent; // Current value of our example resource
        public const int DefaultHolyPoolMax = 100; // Default maximum value of example resource
        public int HolyPoolMax; // maximum amount of Resource
        public int HolyPoolMax2;
        public float HolyPoolRegenRate; // By changing that variable we can increase/decrease regeneration rate of our resource
        internal int HolyPoolRegenTimer = 0; // A variable that is required for our timer
        public bool HolyPoolMagnet = false;
        public static readonly Color HealHolyPoolColor = new(255, 93, 48); // The color to use with CombatText when replenishing HolyPoolCurrent

        // In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health.
        // Here are additional things you might need to implement if you intend to make a custom resource:
        // - Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and CopyClientState will be necessary, as well as SyncPlayer if you allow the user to increase HolyPoolMax.
        // - Save/Load permanent changes to max resource: You'll need to implement Save/Load to remember increases to your HolyPoolMax cap.

        public override void Initialize()
        {
            HolyPoolMax = DefaultHolyPoolMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            HolyPoolRegenRate = 1f;
            HolyPoolMax2 = HolyPoolMax;
            HolyPoolMagnet = false;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        public override void PostUpdate()
        {
            CapResourceGodMode();
        }

        private void UpdateResource()
        {
            HolyPoolRegenTimer++;

            if (HolyPoolRegenTimer >= 60 / HolyPoolRegenRate)
            {
                HolyPoolCurrent += 1;
                HolyPoolRegenTimer = 0;
            }

            // Limit HolyPoolCurrent from going over the limit imposed by HolyPoolMax.
            HolyPoolCurrent = Utils.Clamp(HolyPoolCurrent, 0, HolyPoolMax2);
        }

        private void CapResourceGodMode()
        {
            if (Main.myPlayer == Player.whoAmI && Player.creativeGodMode)
            {
                HolyPoolCurrent = HolyPoolMax2;
            }
        }
    }
}
