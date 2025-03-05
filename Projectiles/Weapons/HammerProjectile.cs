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
    internal class HammerProjectile : ModProjectile
    {
        int numToSpawn = Main.rand.Next(3);
 public override void SetDefaults()
        {
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 3;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 300;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        }


        public override void AI()
        {
            Projectile.velocity.Y += 0.2f;
            if(Projectile.ai[0]==1f&&Projectile.extraUpdates == 0){
                Projectile.velocity*=1.02f;
            }else{
                Projectile.velocity*= 0.98f;
            }

            float rotateSpeed = 0.5f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;

            Lighting.AddLight(Projectile.Center, new Vector3(255f / 255f, 69f / 255f, 0f / 255f));

            if (Main.rand.NextBool(2))
            {
                for (int i = 0; i < numToSpawn; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        ModContent.DustType<HellDust>(),
                        Projectile.velocity.X * 0.1f,
                        Projectile.velocity.Y * 0.1f,
                        0,
                        default(Color),
                        1f
                    );
                }
            }
            foreach(Player player in Main.player){
                if(player!=Main.player[Projectile.owner] && Vector2.Distance(Projectile.Center, player.Center)<16 && player.active){
                    Main.NewText("Projectile hit a player!");
                    player.AddBuff(BuffID.Regeneration, 180);
                    for (int i = 0; i < 3*numToSpawn+2; i++){
                        Dust.NewDust(
                            player.position,
                            player.width,
                            player.height,
                            ModContent.DustType<HealingDust>(),
                            Projectile.velocity.X * 0.1f,
                            Projectile.velocity.Y * 0.1f,
                            0,
                            default(Color),
                            1f
                        );
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire3, 180);
             for (int i = 0; i < numToSpawn; i++){
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    ModContent.DustType<HellDust>(),
                    Projectile.velocity.X * 0.1f,
                    Projectile.velocity.Y * 0.1f,
                    0,
                    default(Color),
                    1f
                );
            }
        }
    }
}
