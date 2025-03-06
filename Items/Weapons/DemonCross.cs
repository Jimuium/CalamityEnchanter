using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityEnchanter.Common.ModPlayers;

namespace CalamityEnchanter.Items.Weapons
{
    internal class DemonCross : ModItem
    {
        int ResourceCost = 20;
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 92;
            Item.autoReuse = false;
            Item.useAnimation = 92;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Blue;

            Item.value = Item.buyPrice(silver: 40, copper: 60);
            Item.maxStack = 1;

            Item.noMelee = true;
            Item.DamageType = ModContent.GetInstance<HexDamageClass>();
            Item.damage = 0;
            Item.knockBack = 0;

            Item.channel = true;
            Item.UseSound = SoundID.Item103;
            Item.shoot = ModContent.ProjectileType<DemonCrossProjectile>();
            Item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar,14);
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddIngredient(ItemID.Ruby,1);
            recipe.AddIngredient(ItemID.VilePowder,6);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            Recipe recipe_alt = CreateRecipe();
            recipe_alt.AddIngredient(ItemID.DemoniteBar,14);
            recipe_alt.AddIngredient(ItemID.PlatinumBar, 1);
            recipe_alt.AddIngredient(ItemID.Ruby,1);
            recipe_alt.AddIngredient(ItemID.VilePowder,6);
            recipe_alt.AddTile(TileID.DemonAltar);
            recipe_alt.Register();

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