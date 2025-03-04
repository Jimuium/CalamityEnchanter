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
    internal class LivingWoodHealingProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;

            Projectile.aiStyle = -1;
            Projectile.scale = 1f;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.velocity *= 0.95f;
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
                        DustID.GemAmethyst
                    );
                }
            }

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                float between = Vector2.Distance(player.Center, Projectile.Center);
                if (i != Projectile.owner && between < 200)
                {
                    Main.NewText("TUUBA");
                    player.Heal(10);
                    Projectile.Kill();
                }
            }
        }
        public override bool? CanHitNPC(NPC target) { return true; }
        public override bool CanHitPlayer(Player target) { return true; }
        public override bool CanHitPvp(Player target) { return true; }
        /*
                public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
                {
                    modifiers.FinalDamage = new(0, 0);
                    modifiers.HideCombatText();
                    modifiers.DisableKnockback();
                    modifiers.
                }
                public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
                {
                    modifiers.Cancel();
                }

                public override void OnHitPlayer(Player target, Player.HurtInfo info)
                {
                    Projectile.ghostHeal(122, Projectile.position, target);
                    target.AddBuff(2, 600); // Add regeneration buff
                }

                public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
                {
                    Projectile.ghostHeal(122, Projectile.position, target);
                    target.AddBuff(2, 600); // Add regeneration buff
                }
            */
    }
}
