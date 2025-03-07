using System;
using System.Collections.Generic;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Dusts.Accessories;
using CalamityEnchanter.Projectiles.Accessories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Accessories
{
    internal class HealingSpirit : ModItem
    {
        public int TotalRegenAmount = 4;
        float resourceRegenDecrease = 0.15f;
        int Duration = 600;

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override bool PreDrawInInventory(
            SpriteBatch spriteBatch,
            Vector2 position,
            Rectangle frame,
            Color drawColor,
            Color itemColor,
            Vector2 origin,
            float scale
        )
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            int frameHeight = 22;
            int frameY = (int)(frameHeight * (Main.GameUpdateCount / 5 % 4));
            Rectangle sourceRectangle = new Rectangle(0, frameY, texture.Width, frameHeight);
            spriteBatch.Draw(
                texture,
                position,
                sourceRectangle,
                drawColor,
                0f,
                origin,
                scale,
                SpriteEffects.None,
                0f
            );
            return false;
        }

        public int cooldown = 360;

        public override void UpdateAccessory(Player target, bool hidevisual)
        {
            cooldown++;
            var HolyPoolPlayer = target.GetModPlayer<HolyPoolPlayer>();
            HolyPoolPlayer.HolyPoolRegenRate -= resourceRegenDecrease;
            if (cooldown >= 390)
            {
                int numberOfProjectiles = 8;
                float baseSpeed = 3f;

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
                $"Periodically bursts a healing aura that buffs Players in its area\nGranting 4 liferegen And 8 defence for {Duration * HolyPoolPlayer.HolyBuffLengthMultiplier / 60} seconds\nReduces Holy regeneration by 15%"
            );
            tooltips.Insert(2, customLine);
        }
    }
}
