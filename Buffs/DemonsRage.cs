using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class DemonsRage : ModBuff
    {
        float DamageBoost = 0.1f;
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update (Player target, ref int buffIndex)
        {
            target.GetDamage(DamageClass.Generic) += DamageBoost;
        }

    }
}