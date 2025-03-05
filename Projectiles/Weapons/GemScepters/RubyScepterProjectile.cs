using CalamityEnchanter.Common.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons.GemScepters
{
    internal class RubyScepterProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();

            Projectile.aiStyle = -1;
            Projectile.scale = 0.75f;

            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
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
                        DustID.GemRuby
                    );
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<Buffs.GemScepters.DiamondBreak>()))
            {
                target.AddBuff(ModContent.BuffType<Buffs.GemScepters.RubyBreak>(), 600);
            }

            var WeakerBuffs = new[]
            {
                ModContent.BuffType<Buffs.GemScepters.AmethystBreak>(),
                ModContent.BuffType<Buffs.GemScepters.TopazBreak>(),
                ModContent.BuffType<Buffs.GemScepters.SapphireBreak>(),
                ModContent.BuffType<Buffs.GemScepters.EmeraldBreak>(),
            };

            foreach (var buff in WeakerBuffs)
            {
                if (target.HasBuff(buff))
                {
                    target.DelBuff(target.FindBuffIndex(buff));
                }
            }
        }
    }
}
