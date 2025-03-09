﻿using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class HolyPalladinLeggins : ModItem
    {
        float DamageIncrease = 0.1f;
        float ResourceIncrease = 0.06f;

        public static readonly int MaxManaIncrease = 20;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxManaIncrease);

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 22;
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
