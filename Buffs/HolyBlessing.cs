using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class HolyBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 4;
            player.statDefense += 8;
        }
    }
}
