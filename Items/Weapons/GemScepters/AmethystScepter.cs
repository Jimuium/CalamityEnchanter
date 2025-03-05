using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
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
        int ResourceCost = 5;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(silver: 5);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<WrathHexDamageClass>();
            Item.damage = 18;
            Item.knockBack = 5f;

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
