using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Common.DamageClasses
{
    public class WrathHexDamageClass : DamageClass
    {
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            // Determines inheritance from other damage types
            if (
                damageClass == DamageClass.Generic
                || damageClass == ModContent.GetInstance<HexDamageClass>()
            )
            {
                return true;
            }
            return false;
        }

        public override bool UseStandardCritCalcs => true; // Uses standard crit calculations
    }
}
