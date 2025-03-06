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

namespace CalamityEnchanter.Projectiles.Weapons.GemScepters
{
    internal class AmethystScepterProjectile : ModProjectile
    {
        int num = Main.rand.Next(3, 8);

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<WrathHexDamageClass>();

            Projectile.aiStyle = -1;
            Projectile.scale = 0.75f;

            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 60)
            {
                for (int i = 0; i < num; i++)
                {
                    double angle = i * Math.PI / (2 * num - 1) + Math.PI / 4;
                    Dust.NewDust(
                        Projectile.Center,
                        Projectile.width,
                        Projectile.height,
                        DustID.GemAmethyst,
                        (float)(Math.Cos(angle) * 2),
                        (float)(Math.Sin(angle) * -3)
                    );
                }
                Projectile.Kill();
            }

            Projectile.rotation =
                Projectile.velocity.ToRotation()
                + MathHelper.PiOver2
                - MathHelper.PiOver4 * Projectile.spriteDirection;

            Lighting.AddLight(Projectile.Center, new Vector3(141f / 255f, 76f / 255f, 167f / 255f));

            if (Main.rand.NextBool(2))
            {
                for (int i = 0; i < num; i++)
                {
                    int index = Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.GemAmethyst
                    );

                    Dust dust = Main.dust[index];
                    dust.noGravity = true;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int numToSpawn = Main.rand.Next(3, 8);
            for (int i = 0; i < numToSpawn; i++)
            {
                double angle = i * Math.PI / (2 * numToSpawn - 1) + Math.PI / 4;
                Dust.NewDust(
                    target.Center,
                    Projectile.width,
                    Projectile.height,
                    DustID.GemAmethyst,
                    (float)(Math.Cos(angle) * 2),
                    (float)(Math.Sin(angle) * -3)
                );
            }
            ;

            if (
                !target.HasBuff(ModContent.BuffType<Buffs.GemScepters.TopazBreak>())
                && !target.HasBuff(ModContent.BuffType<Buffs.GemScepters.SapphireBreak>())
                && !target.HasBuff(ModContent.BuffType<Buffs.GemScepters.EmeraldBreak>())
                && !target.HasBuff(ModContent.BuffType<Buffs.GemScepters.RubyBreak>())
                && !target.HasBuff(ModContent.BuffType<Buffs.GemScepters.DiamondBreak>())
            )
            {
                target.AddBuff(ModContent.BuffType<Buffs.GemScepters.AmethystBreak>(), 600);
            }
        }
    }
}
