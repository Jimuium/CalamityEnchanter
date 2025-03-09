using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using CalamityEnchanter.Dusts.Weapons;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles
{
    public class TurtlePetProjectile : ModProjectile
    {
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 8;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
		}
        public override void SetDefaults() {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.minion = false;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

			if (!player.active) {
				Projectile.active = false;
				return;
			}

			// Keep the projectile disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<TurtlePetBuff>())) {
				Projectile.timeLeft = 2;
			}
                Projectile.frameCounter += Projectile.wet ? 1 : 2;
                int framesPerState = Main.projFrames[Projectile.type] / 2;
                Projectile.spriteDirection = Projectile.velocity.X > 0 ? -1 : 1;
                if (Projectile.frameCounter >= 10) {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                }
                if (Projectile.wet) {
                    if (Projectile.frame < 0 || Projectile.frame >= framesPerState) {
                        Projectile.frame = 0;
                    }
                }
                else{
                    if (Projectile.frame < framesPerState || Projectile.frame >= Main.projFrames[Projectile.type]) {
                        Projectile.frame = framesPerState;
                    }
                }
                
                Vector2 idlePosition = player.Center;
                idlePosition.X -= player.direction * 60f;  // Horizontal offset based on player direction.
                idlePosition.Y += -60f;                    // Vertical offset (above the player).

                // Calculate the vector to the idle position.
                Vector2 toIdle = idlePosition - Projectile.Center;
                float distanceToIdle = toIdle.Length();

                // Teleport pet if it’s too far from the player.
                if (distanceToIdle > 1200f) {
                    Projectile.position = idlePosition;
                    Projectile.velocity = Vector2.Zero;
                    return;
                }

                // Set speed and inertia values.
                float speed = 18f;   // Default movement speed on land.
                float inertia = 10f; // Determines how smoothly the pet accelerates.

                if (Projectile.wet) {
                    // When underwater, the pet should move faster and be more responsive.
                    speed = 7f;   // Increased speed underwater.
                    inertia = 25f; // Lower inertia means quicker changes in velocity.
                }

                // If the pet is far enough from the idle position, accelerate toward it.
                if (distanceToIdle > 20f) {
                    toIdle.Normalize();
                    toIdle *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + toIdle) / inertia;
                } else {
                    // If close enough, slow down smoothly.
                    Projectile.velocity *= 0.9f;
                }
                Lighting.AddLight(Projectile.Center, new Vector3(1, 1, 80/255));
        }
    }
}