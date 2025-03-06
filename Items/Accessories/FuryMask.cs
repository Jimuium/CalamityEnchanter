using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    [AutoloadEquip(EquipType.Face)]
    internal class FuryMask : ModItem
    {
        int FuryEnergyCostMultiplier = 2;
        float damageIncrease = 0.2f;
        float critChanceIncrease = 20f;

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hidevisual)
        {
            player.GetDamage(ModContent.GetInstance<WrathHexDamageClass>()) += damageIncrease;
            player.GetCritChance(ModContent.GetInstance<WrathHexDamageClass>()) +=
                critChanceIncrease;
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();
            FuryEnergyPlayer.FuryEnergyCostMultiplier *= FuryEnergyCostMultiplier;
        }
    }
}
