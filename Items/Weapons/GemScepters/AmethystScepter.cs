using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons.GemScepters;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons.GemScepters
{
    internal class AmethystScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.White;

            Item.value = Item.buyPrice(silver: 5);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 28;
            Item.damage = 12;
            Item.knockBack = 4f;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<AmethystScepterProjectile>();
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperBar, 12)
                .AddIngredient(ItemID.Amethyst, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }
    }
}
