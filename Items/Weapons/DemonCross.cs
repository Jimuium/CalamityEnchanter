using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class DemonCross : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 92;
            Item.autoReuse = false;
            Item.useAnimation = 92;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Blue;

            Item.value = Item.buyPrice(silver: 40, copper: 60);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 20;
            Item.damage = 0;
            Item.knockBack = 0;

            Item.channel = true;
            Item.UseSound = SoundID.Item103;
            Item.shoot = ModContent.ProjectileType<DemonCrossProjectile>();
            Item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar,14);
            recipe.AddIngredient(ItemID.Ruby,1);
            recipe.AddIngredient(ItemID.VilePowder,6);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}