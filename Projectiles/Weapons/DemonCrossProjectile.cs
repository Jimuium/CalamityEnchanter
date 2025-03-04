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
    internal class DemonCrossProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();

        Projectile.aiStyle = -1;

        Projectile.penetrate = 3;
        }
        public override void PostAI()
        {
            Player target = Main.player[Projectile.owner];
            Projectile.localAI[1]++;
            Projectile.position = target.position;
            Main.NewText("Projectile at:" + Projectile.position);
            if (Projectile.localAI[1] % 5 == 0)
            {
                for (int i = 1; i < 90; i++)
                {
                    Main.NewText("Dust at: " + new Vector2(64 * (float)Math.Cos(i * 4), 64 * (float)Math.Sin(i * 4)) + target.position);
                    Dust.NewDustPerfect
                    (
                        new Vector2(64 * (float)Math.Cos(i * Math.PI /45), 64 * (float)Math.Sin(i * Math.PI /45)) + target.position,
                        ModContent.DustType<DemonDust>()
                    );
                }
            }
            if (Projectile.localAI[1] == 19)
            {
                Projectile.Kill();
            }
        }
    }
}
