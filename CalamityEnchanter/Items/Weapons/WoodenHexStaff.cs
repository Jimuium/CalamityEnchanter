using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class WoodenHexStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 32;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 4;
            Item.damage = 8;
            Item.knockBack = 2f;

            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<WoodenHexStaffProjectile>();
            Item.shootSpeed = 12f;
        }
    }
}
