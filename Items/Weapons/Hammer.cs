using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class Hammer : ModItem
    {
        int ResourceCost = 3;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.DamageType = ModContent.GetInstance<WrathHexDamageClass>();
            Item.noMelee = true;
            Item.damage = 32;
            Item.knockBack = 8.0f;

            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<HammerProjectile>();
            Item.shootSpeed = 25f;
            Item.value = Item.buyPrice(gold: 2, silver: 50);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 12)
                .AddIngredient(ItemID.Fireblossom, 6)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();

            return FuryEnergyPlayer.FuryEnergyCurrent >= ResourceCost;
        }

        public override bool? UseItem(Player player)
        {
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();

            FuryEnergyPlayer.FuryEnergyCurrent -= ResourceCost;

            return true;
        }
    }
}
