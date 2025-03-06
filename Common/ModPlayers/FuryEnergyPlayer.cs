using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Common.ModPlayers
{
    public class FuryEnergyPlayer : ModPlayer
    {
        // Here we create a custom resource, similar to mana or health.
        // Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
        public float FuryEnergyCurrent; // Current value of our example resource
        public const int DefaultFuryEnergyMax = 100; // Default maximum value of example resource
        public int FuryEnergyMax; // maximum amount of Resource
        public int FuryEnergyMax2;
        public float FuryEnergyRegenRate; // By changing that variable we can increase/decrease regeneration rate of our resource
        internal int FuryEnergyRegenTimer = 0; // A variable that is required for our timer
        public bool FuryEnergyMagnet = false;
        public float FuryEnergyCostMultiplier = 1; // How many times more using items costs resource
        public float FuryBuffLengthIncrease = 1;
        public float FuryBuffStrengthIncrease = 1;

        // In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health.
        // Here are additional things you might need to implement if you intend to make a custom resource:
        // - Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and CopyClientState will be necessary, as well as SyncPlayer if you allow the user to increase FuryEnergyMax.
        // - Save/Load permanent changes to max resource: You'll need to implement Save/Load to remember increases to your FuryEnergyMax cap.

        public override void Initialize()
        {
            FuryEnergyMax = DefaultFuryEnergyMax;
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
            FuryEnergyRegenRate = 1f;
            FuryEnergyMax2 = FuryEnergyMax;
            FuryEnergyMagnet = false;
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
            FuryEnergyRegenTimer++;

            if (FuryEnergyRegenTimer >= 30)
            {
                FuryEnergyCurrent += FuryEnergyMax2 * FuryEnergyRegenRate / 200;
                FuryEnergyRegenTimer = 0;
            }

            // Limit FuryEnergyCurrent from going over the limit imposed by FuryEnergyMax.
            FuryEnergyCurrent = Utils.Clamp(FuryEnergyCurrent, 0, FuryEnergyMax2);
        }

        private void CapResourceGodMode()
        {
            if (Main.myPlayer == Player.whoAmI && Player.creativeGodMode)
            {
                FuryEnergyCurrent = FuryEnergyMax2;
            }
        }
    }
}
