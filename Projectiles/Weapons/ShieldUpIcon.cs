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
    internal class ShieldUpIcon : ModProjectile
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
            Projectile.velocity.Y = -2f;
            Projectile.velocity.Y -=0.1f;
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 60)
            {
                Projectile.Kill();
            }
            Lighting.AddLight(Projectile.Center, new Vector3(255f / 150f, 255f / 150f, 255f / 150f));
        }
    }
}
