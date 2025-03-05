using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class StoneStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.HoldUp;

            Item.noMelee = true;
            Item.mana = 2;
            Item.damage = 0;
            Item.knockBack = 0f;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<StoneStaffProjectile>();
            Item.shootSpeed = 0f;
            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().Register();
        }
    }
}
