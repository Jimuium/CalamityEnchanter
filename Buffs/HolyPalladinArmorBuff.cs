using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class HolyPalladinArmorBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<DamageModificationPlayer>().defendedByAbsorbTeamDamageEffect = true;
        }
    }
}
