using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class PainConverterUpgrade : ModItem
    {
        float healthToFuryEnergyRate = 0.25f;

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hidevisual)
        {
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();
            FuryEnergyPlayer.convertHealthToFury += healthToFuryEnergyRate;
        }

        public override bool CanAccessoryBeEquippedWith(
            Item equippedItem,
            Item incomingItem,
            Player player
        )
        {
            if (
                equippedItem.type == ModContent.ItemType<PainConverterUpgrade>()
                && incomingItem.type == ModContent.ItemType<PainConverter>()
            )
            {
                return false;
            }
            return true;
        }
    }
}
