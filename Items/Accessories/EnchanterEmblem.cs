using CalamityEnchanter.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class EnchanterEmblem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hidevisual)
        {
            player.GetDamage(ModContent.GetInstance<HexDamageClass>()) += 0.15f;
        }
    }
}
