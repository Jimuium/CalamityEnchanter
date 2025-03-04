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
            Item.useTime = 20;
            Item.autoReuse = true;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;

            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 4;
            Item.damage = 8;
            Item.knockBack = 2f;

            Item.UseSound = SoundID.Item103;
            Item.shoot = ModContent.ProjectileType<DemonCrossProjectile>();
            Item.shootSpeed = 12f;

        }
    }
}