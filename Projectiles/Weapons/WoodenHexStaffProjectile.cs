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
    internal class WoodenHexStaffProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();

            Projectile.aiStyle = -1;

            Projectile.penetrate = 3;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.velocity *= 0.995f;
            if (Projectile.ai[0] == 60)
            {
                Projectile.Kill();
            }

            Projectile.rotation =
                Projectile.velocity.ToRotation()
                + MathHelper.PiOver2
                - MathHelper.PiOver4 * Projectile.spriteDirection;

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
                        ModContent.DustType<HexDust>(),
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
            target.AddBuff(ModContent.BuffType<Buffs.Tier1HexedDebuff>(), 240);
        }
    }
}
