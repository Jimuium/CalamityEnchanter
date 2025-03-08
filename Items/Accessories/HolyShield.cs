using System;
using System.Collections.Generic;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Dusts.Accessories;
using CalamityEnchanter.Projectiles.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class HolyShield : ModItem
    {
        public int TotalRegenAmount = 4;
        int Duration = 600;
        float DamageIncrease = 15;

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 120;
            Item.knockBack = 4f;
            Item.DamageType = ModContent.GetInstance<HolyHexDamageClass>();
        }

        public int cooldown = 360;

        public override void UpdateAccessory(Player target, bool hidevisual)
        {
            cooldown++;
            var HolyPoolPlayer = target.GetModPlayer<HolyPoolPlayer>();
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
                if (!hidevisual)
                {
                    for (int i = 0; i < numberOfProjectiles * 8; i++)
                    {
                        double angle = MathHelper.ToRadians(i * 360 / (numberOfProjectiles * 8));
                        Vector2 velocity =
                            new Vector2(
                                baseSpeed * (float)Math.Cos(angle),
                                baseSpeed * (float)Math.Sin(angle)
                            ) * 8;

                        Dust.NewDust(
                            target.Center,
                            40,
                            40,
                            ModContent.DustType<HolyShieldDust>(),
                            velocity.X,
                            velocity.Y
                        );
                    }
                }
                foreach (Player player in Main.player)
                {
                    if (player.active && Vector2.Distance(player.position, target.position) < 540)
                        player.AddBuff(
                            ModContent.BuffType<HolyBlessing>(),
                            (int)(Duration * HolyPoolPlayer.HolyBuffLengthMultiplier)
                        );
                    Dust.NewDustPerfect(
                        player.Center - new Vector2(0, target.height),
                        ModContent.DustType<BlessingDust>(),
                        new Vector2(0, -1)
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
                $"Occasionally Summons 8 circling projectiles around you that hurt enemies \nPeriodicly bursts a healing aura that buffs Players in its area\nGranting 4 liferegen And 8 defence for {Duration * HolyPoolPlayer.HolyBuffLengthMultiplier / 60} seconds\nIncreases Holy damage by {DamageIncrease}%"
            );
            tooltips.Insert(3, customLine);
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            foreach (Item equippedItem in player.armor)
            {
                if (
                    equippedItem.type == ModContent.ItemType<MysteriousCrystal>()
                    || equippedItem.type == ModContent.ItemType<HealingSpirit>()
                )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
