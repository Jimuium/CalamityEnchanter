using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class CursedStaff : ModItem
    {
        int ResourceCost = 2;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = ModContent.GetInstance<WrathHexDamageClass>();
            Item.noMelee = true;
            Item.damage = 8;
            Item.knockBack = 3.0f;

            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<CursedStaffProjectile>();
            Item.shootSpeed = 10f;
            Item.value = Item.buyPrice(gold: 1);
            Item.maxStack = 1;
        }

        public override bool CanUseItem(Player player)
        {
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();

            return FuryEnergyPlayer.FuryEnergyCurrent >= ResourceCost;
        }

        public override bool? UseItem(Player player)
        {
            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();

            FuryEnergyPlayer.FuryEnergyCurrent -= ResourceCost;

            return true;
        }
    }
}
