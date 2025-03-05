using CalamityEnchanter.DamageClasses;
using CalamityEnchanter.Dusts.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffs
{
    public class DemonsRage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update (Player target, ref int buffIndex)
        {
            target.GetDamage(DamageClass.Generic) *= 1.1f;
        }

    }
}