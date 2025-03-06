using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class WrathRing : ModItem
    {
        float regenerationIncrease = 0.50f;
        float OtherDamageDecrease = 0.1f;

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hidevisual)
        {
            player.GetDamage(ModContent.GetInstance<CalmDamageClass>()) -= OtherDamageDecrease;
            player.GetDamage(ModContent.GetInstance<HolyHexDamageClass>()) -= OtherDamageDecrease;
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();
            FuryEnergyPlayer.FuryEnergyRegenRate += regenerationIncrease;
        }
    }
}
