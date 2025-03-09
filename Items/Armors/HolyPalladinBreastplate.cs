using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class HolyPalladinBreastplate : ModItem
    {
        float DamageIncrease = 0.15f;
        float ResourceIncrease = 0.08f;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 28;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<HolyHexDamageClass>()) += DamageIncrease;
            var HolyPoolPlayer = player.GetModPlayer<HolyPoolPlayer>();
            HolyPoolPlayer.HolyPoolRegenRate += ResourceIncrease;
        }

        public override void AddRecipes()
        {
            CreateRecipe().Register();
        }
    }
}
