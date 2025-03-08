using System;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons
{
    internal class HexWandProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<WrathHexDamageClass>();

            Projectile.aiStyle = -1;

            Projectile.penetrate = 3;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 15)
            {
                if (Projectile.velocity.Length() < 25f)
                {
                    Projectile.velocity *= 1 + Projectile.ai[0] / 50;
                }
            }
            if (Projectile.ai[0] == 120)
            {
                Projectile.Kill();
            }

            Projectile.rotation =
                Projectile.velocity.ToRotation()
                + MathHelper.PiOver2
                - MathHelper.PiOver4 * Projectile.spriteDirection;

            Lighting.AddLight(Projectile.Center, new Vector3(141f / 255f, 76f / 255f, 167f / 255f));

            for (int i = 0; i < 3; i++)
            {
                if (i > 2)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        ModContent.DustType<HexDust>(),
                        Projectile.velocity.X * 1f,
                        Projectile.velocity.Y * 1f
                    );
                }
                else
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        ModContent.DustType<DarkHexDust>(),
                        Projectile.velocity.X * 0.5f,
                        Projectile.velocity.Y * 0.5f
                    );
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Tier1HexedDebuff>(), 360);
        }
    }
}
