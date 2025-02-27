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
    internal class StoneStaffProjectile : ModProjectile
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
            foreach(Player player in Main.player){
                if(player.active && Math.Sqrt((player.position.X-Main.LocalPlayer.position.X)*(player.position.X-Main.LocalPlayer.position.X)+(player.position.Y-Main.LocalPlayer.position.Y)*(player.position.Y-Main.LocalPlayer.position.Y))<100){
                    //player.AddBuff(ModContent.BuffType<Buffs.StoneShieldUp>(), 240);
                    Projectile.NewProjectile(
                        Main.LocalPlayer.GetSource_FromThis(),
                        player.position,
                        Vector2.Zero,
                        ModContent.ProjectileType<ShieldUpIcon>(),
                        1,
                        1
                    );
                }
            }
            Projectile.Kill();

            Lighting.AddLight(Projectile.Center, new Vector3(255f/255f,255f/255f,255f/255f));

            if (Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for (int i = 0; i < numToSpawn; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        ModContent.DustType<StoneDust>(),
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
}
