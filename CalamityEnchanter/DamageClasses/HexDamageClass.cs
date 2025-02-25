using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.DamageClasses
{
    public class HexDamageClass : DamageClass
    {

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            // Determines inheritance from other damage types
            if (damageClass == DamageClass.Generic)
            {
                return true;
            }
            return false;
        }

        public override bool UseStandardCritCalcs => false; // Uses standard crit calculations
    }
}
