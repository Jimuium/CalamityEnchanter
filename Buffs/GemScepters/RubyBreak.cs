using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs.GemScepters
{
    public class RubyBreak : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC target, ref int buffIndex)
        {
            target.defDefense -= 5;
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(target.position, target.width, target.height, DustID.GemRuby);
            }
        }
    }
}
