using System;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Projectiles.Weapons
{
    internal class BloodyCrossProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.DamageType = ModContent.GetInstance<HexDamageClass>();
        Projectile.tileCollide = false;

        Projectile.aiStyle = -1;

        Projectile.penetrate = 3;
        }
        public override void AI()
        {
            Player target = Main.player[Projectile.owner];
            Projectile.localAI[1]++;
            Projectile.position = target.position;
            if (Projectile.localAI[1] % 5 == 0)
            {
                for (int i = 1; i < 360; i++)
                {
                    Dust.NewDust
                    (
                        new Vector2(96 * (float)Math.Cos(i), 96 * (float)Math.Sin(i)) + target.position,
                        16,
                        16,                        
                        ModContent.DustType<BloodyDust>(),
                        Projectile.velocity.X * 0.1f,
                        Projectile.velocity.Y * 0.1f
                    );
                }
            }
            if (Projectile.localAI[1] == 25)
            {
                Projectile.Kill();
            }
            int damagePool = 0;
            foreach(Player player in Main.player)
            {
                if(player.active && Vector2.Distance(player.Center, Projectile.Center) < 96 && !target.HasBuff(ModContent.BuffType<Buffs.DemonsRage>()))
                {
                    damagePool += 10;
                    player.AddBuff(ModContent.BuffType<Buffs.Bloodlust>(), 900);
                }
            }
            if (Projectile.ai[1] == 0)
            {
                target.statLife -= damagePool;
                CombatText.NewText(target.Hitbox, Color.Red, damagePool, true, false);
                Projectile.ai[1]=1;
            }
            
            if (target.statLife <= 0)
            {
                target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " bled out!"), damagePool, 0);
            }
        }
    }
} 
