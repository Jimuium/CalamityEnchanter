using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class Bloodlust : ModBuff
    {
        float CritBoost = 10f;
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update (Player target, ref int buffIndex)
        {
            target.GetCritChance(DamageClass.Generic) += CritBoost;
        }

    }
}