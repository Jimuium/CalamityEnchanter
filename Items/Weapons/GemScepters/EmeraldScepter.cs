using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons.GemScepters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons.GemScepters
{
    internal class EmeraldScepter : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 60;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.mana = 20;
            Item.damage = 20;
            Item.knockBack = 2f;

            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<EmeraldScepterProjectile>();
            Item.shootSpeed = 12f;
        }
    }
}
