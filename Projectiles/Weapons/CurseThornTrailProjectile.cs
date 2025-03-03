using System;
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
    internal class CurseThornTrailProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.tileCollide = false;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();

            Projectile.aiStyle = -1;

            Projectile.penetrate = -1;

        }

        public override void AI()
        {
            Projectile.rotation = Projectile.ai[1];
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 60)
            {
                Projectile.Kill();
            }
            Vector2 offset = Projectile.velocity.SafeNormalize(Vector2.Zero) * -8f;
            Vector2 spawnPos = Projectile.Center + offset;
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Tier1HexedDebuff>(), 240);
        }
    }
}
