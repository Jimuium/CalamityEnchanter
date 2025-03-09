using System;
using System.Collections.Generic;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class RageAmplifier : ModItem
    {
        float MaxDamageIncrease = 0.30f;
        float MaxDamageThreshold = 0.1f; //remaining hp%

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hidevisual)
        {
            float currentHpPercent = player.statLife / (float)player.statLifeMax;

            float missingHpPercent = 1 - currentHpPercent;

            float scale = Math.Min(missingHpPercent / (1 - MaxDamageThreshold), 1);

            player.GetDamage(ModContent.GetInstance<WrathHexDamageClass>()) += (float)
                Math.Round(MaxDamageIncrease * scale, 2);
        }
    }
}
