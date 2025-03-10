using CalamityEnchanter.Common.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class CurseSlowdown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC target, ref int buffIndex)
        {
            if (target.buffTime[buffIndex] % 60 == 0)
            {
                target.SimpleStrikeNPC(
                    10,
                    1,
                    false,
                    0,
                    ModContent.GetInstance<WrathHexDamageClass>()
                );
            }
            target.velocity *= 0.975f;

            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(target.position, target.width, target.height, DustID.Water_BloodMoon);
            }
        }
    }
}
