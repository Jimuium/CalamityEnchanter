using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs.GemScepters
{
    public class DiamondBreak : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC target, ref int buffIndex)
        {
            target.defDefense -= 4;
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
