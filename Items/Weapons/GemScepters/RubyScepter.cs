using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons.GemScepters;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons.GemScepters
{
    internal class RubyScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.value = Item.buyPrice(silver: 50);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 16;
            Item.damage = 22;
            Item.knockBack = 7f;

            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<RubyScepterProjectile>();
            Item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 12)
                .AddIngredient(ItemID.Ruby, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }
    }
}
