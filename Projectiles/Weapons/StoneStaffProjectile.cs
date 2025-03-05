using System;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Iced.Intel;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons
{
    internal class StoneStaffProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;

            Projectile.aiStyle = -1;

            Projectile.penetrate = 3;
        }

        public override void AI()
        {
            foreach (Player player in Main.player)
            {
                if (
                    player.active
                    && Math.Sqrt(
                        (player.position.X - Main.LocalPlayer.position.X)
                            * (player.position.X - Main.LocalPlayer.position.X)
                            + (player.position.Y - Main.LocalPlayer.position.Y)
                                * (player.position.Y - Main.LocalPlayer.position.Y)
                    ) < 500
                )
                {
                    //player.AddBuff(ModContent.BuffType<Buffs.StoneShieldUp>(), 240);
                    Projectile.NewProjectile(
                        Main.LocalPlayer.GetSource_FromThis(),
                        player.position,
                        Vector2.Zero,
                        ModContent.ProjectileType<ShieldUpIcon>(),
                        1,
                        1
                    );
                }
            }
            Projectile.Kill();

            Lighting.AddLight(
                Projectile.Center,
                new Vector3(255f / 255f, 255f / 255f, 255f / 255f)
            );
            for (int i = 0; i < 180; i++)
            {
                double x = Math.Cos(i * Math.PI / 90);
                double y = Math.Sin(i * Math.PI / 90);
                Vector2 dustPosition = new Vector2(
                    Projectile.position.X + (float)x,
                    Projectile.position.Y + (float)y
                );
                Vector2 direction = dustPosition - Projectile.position;
                Dust.NewDustPerfect(
                    new Vector2(
                        Projectile.position.X + (int)(x * 500),
                        Projectile.position.Y + (int)(y * 500)
                    ),
                    ModContent.DustType<StoneDust>(),
                    direction,
                    0,
                    default(Color),
                    1f
                );
                if (i % 30 == 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Dust.NewDustPerfect(
                            new Vector2(
                                Projectile.position.X + (int)(j * x * 50),
                                Projectile.position.Y + (int)(j * y * 50)
                            ),
                            ModContent.DustType<StoneDust>(),
                            direction,
                            0,
                            default(Color),
                            1f
                        );
                    }
                }
            }

            /*if (Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for (int i = 0; i < numToSpawn; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        ModContent.DustType<StoneDust>(),
                        Projectile.velocity.X * 0.1f,
                        Projectile.velocity.Y * 0.1f,
                        0,
                        default(Color),
                        1f
                    );
                }
            }*/
        }
    }
}
