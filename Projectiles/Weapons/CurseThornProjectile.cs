using CalamityEnchanter.Buffs;
using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons
{
    internal class CurseThornProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();

            Projectile.aiStyle = -1;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 60)
            {
                Projectile.velocity = Vector2.Zero;
                if (Projectile.ai[0] == 120)
                {
                    Projectile.Kill();
                }
            }
            else
            {
                Projectile.velocity *= 0.995f;
                Vector2 offset = Projectile.velocity.SafeNormalize(Vector2.Zero);
                Vector2 spawnPos = Projectile.Center + offset;
                Projectile.rotation =
                   Projectile.velocity.ToRotation()
                   + MathHelper.PiOver2
                   - MathHelper.PiOver4 * Projectile.spriteDirection;
                    if(Projectile.ai[0]%5 == 0){
                    Projectile.NewProjectile(
                        Projectile.GetSource_FromThis(),
                        spawnPos,
                        Vector2.Zero,  // trail projectile remains stationary or can have its own behavior
                        ModContent.ProjectileType<CurseThornTrailProjectile>(),
                        Projectile.damage,
                        Projectile.knockBack,
                        Projectile.owner,
                        ai0: 0f,
                        ai1: Projectile.rotation
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
