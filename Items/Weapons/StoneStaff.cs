using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Projectiles.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Weapons
{
    internal class StoneStaff : ModItem
    {
        int ResourceCost = 15;

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
            Item.damage = 0;
            Item.knockBack = 0f;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<StoneStaffProjectile>();
            Item.shootSpeed = 0f;
            Item.value = Item.buyPrice(silver: 69, copper: 69);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 24)
                .AddRecipeGroup(RecipeGroupID.IronBar, 6)
                .AddIngredient(ItemID.Diamond, 2)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            var HolyPoolPlayer = player.GetModPlayer<HolyPoolPlayer>();

            return HolyPoolPlayer.HolyPoolCurrent >= ResourceCost;
        }

        public override bool? UseItem(Player player)
        {
            var HolyPoolPlayer = player.GetModPlayer<HolyPoolPlayer>();

            HolyPoolPlayer.HolyPoolCurrent -= ResourceCost;

            return true;
        }
    }
}
