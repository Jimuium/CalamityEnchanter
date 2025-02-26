using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons.GemScepters;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons.GemScepters
{
    internal class SapphireScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;

            Item.value = Item.buyPrice(silver: 25);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 22;
            Item.damage = 16;
            Item.knockBack = 5f;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<SapphireScepterProjectile>();
            Item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 12)
                .AddIngredient(ItemID.Sapphire, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }
    }
}
