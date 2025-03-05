using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class Tier1HexedDebuff : ModBuff
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
                target.SimpleStrikeNPC(8, 1, false, 0, ModContent.GetInstance<HexDamageClass>());
            }
            target.velocity *= 0.9f;

            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(
                    target.position,
                    target.width,
                    target.height,
                    ModContent.DustType<HexDust>()
                );
            }
        }
    }
}
