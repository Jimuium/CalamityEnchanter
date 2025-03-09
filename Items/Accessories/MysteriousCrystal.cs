using System;
using System.Collections.Generic;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Projectiles.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class MysteriousCrystal : ModItem
    {
        int DamageIncrease = 10;

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 80;
            Item.knockBack = 4f;
            Item.DamageType = ModContent.GetInstance<HolyHexDamageClass>();
        }

        public int cooldown = 360;

        public override void UpdateAccessory(Player target, bool hidevisual)
        {
            cooldown++;
            target.GetDamage(ModContent.GetInstance<HolyHexDamageClass>()) += DamageIncrease / 100;
            if (cooldown >= 390)
            {
                int numberOfProjectiles = 8;
                float baseSpeed = 3f;

                for (int i = 0; i < numberOfProjectiles; i++)
                {
                    double angle = MathHelper.ToRadians(i * 360 / numberOfProjectiles);
                    Vector2 velocity = new Vector2(
                        baseSpeed * (float)Math.Cos(angle),
                        baseSpeed * (float)Math.Sin(angle)
                    );

                    Projectile.NewProjectile(
                        target.GetSource_FromThis(),
                        target.Center,
                        velocity,
                        ModContent.ProjectileType<HolyShieldProjectile>(),
                        Item.damage,
                        Item.knockBack,
                        target.whoAmI
                    );
                }
                cooldown = 0;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var HolyPoolPlayer = Main.player[Item.whoAmI].GetModPlayer<HolyPoolPlayer>();
            TooltipLine customLine = new TooltipLine(
                Mod,
                "HealAmount",
                $"Occasionally Summons 8 circling projectiles around you that hurt enemies\nIncreases Holy damage by {DamageIncrease}%"
            );
            tooltips.Insert(3, customLine);
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            foreach (Item equippedItem in player.armor)
            {
                if (equippedItem.type == ModContent.ItemType<HolyShield>())
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 12)
                .AddIngredient(ItemID.MythrilBar, 8)
                .AddRecipeGroup("greenDyes", 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe recipe_alt = CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 12)
                .AddIngredient(ItemID.OrichalcumBar, 8)
                .AddRecipeGroup("greenDyes", 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
