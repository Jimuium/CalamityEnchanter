using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons.GemScepters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons.GemScepters
{
    internal class TopazScepter : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 60;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 26;
            Item.damage = 12;
            Item.knockBack = 2f;

            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<TopazScepterProjectile>();
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TinBar, 12)
                .AddIngredient(ItemID.Topaz, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
