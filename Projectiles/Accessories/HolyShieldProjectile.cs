using System;
using System.Collections.Generic;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Accessories
{
    internal class HolyShieldProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 390;
            Projectile.aiStyle = -1;

            Projectile.penetrate = 20;
        }

        float angleInRadians = 0.016f;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            float cosTheta = MathF.Cos(angleInRadians);
            float sinTheta = MathF.Sin(angleInRadians);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.position += Projectile.velocity + player.velocity;
            Projectile.velocity = new Vector2(
                Projectile.velocity.X * cosTheta - Projectile.velocity.Y * sinTheta,
                Projectile.velocity.X * sinTheta + Projectile.velocity.Y * cosTheta
            );
            Lighting.AddLight(Projectile.Center, 214f / 255f, 1f, 0f);
        }
    }
}
