using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class Hammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.noMelee = true;
            Item.mana = 8;
            Item.damage = 20;
            Item.knockBack = 3.0f;

            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<HammerProjectile>();
            Item.shootSpeed = 30f;
            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().Register();
        }
    }
}
