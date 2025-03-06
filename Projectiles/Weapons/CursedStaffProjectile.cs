using CalamityEnchanter.Common.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons
{
    internal class CursedStaffProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<WrathHexDamageClass>();

            Projectile.aiStyle = -1;

            Projectile.penetrate = 10;
        }

        public override void AI()
        {
            Projectile.velocity.Y += 0.1f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            Projectile.ai[0]++;
            Projectile.velocity *= 1.005f;
            if (Projectile.ai[0] == 60)
            {
                Projectile.Kill();
            }
            float rotateSpeed = 0.5f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;

            Lighting.AddLight(Projectile.Center, new Vector3(141f / 255f, 76f / 255f, 167f / 255f));

            if (Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for (int i = 0; i < numToSpawn; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Water_BloodMoon,
                        Projectile.velocity.X * 0.1f,
                        Projectile.velocity.Y * 0.1f,
                        0,
                        default(Color),
                        1f
                    );
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.CurseSlowdown>(), 240);
        }
    }
}
