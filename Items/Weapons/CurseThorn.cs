using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalamityEnchanter.Items.Weapons
{
    internal class CurseThorn : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.value = Item.buyPrice(gold: 2, silver: 20);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 15;
            Item.damage = 10;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<CurseThornProjectile>();
            Item.shootSpeed = 4f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowScale, 6)
                .AddIngredient(ItemID.DemoniteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}