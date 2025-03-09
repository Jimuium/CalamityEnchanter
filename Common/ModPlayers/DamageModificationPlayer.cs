using CalamityEnchanter.Items.Armors;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Common.ModPlayers
{
    internal class DamageModificationPlayer : ModPlayer
    {
        public float AdditiveCritDamageBonus;

        public bool hasAbsorbTeamDamageEffect;
        public bool defendedByAbsorbTeamDamageEffect;
        public bool exampleDefenseDebuff;
        public float AbsorbDamageStrength;

        public override void ResetEffects()
        {
            AdditiveCritDamageBonus = 0f;
            hasAbsorbTeamDamageEffect = false;
            defendedByAbsorbTeamDamageEffect = false;
            exampleDefenseDebuff = false;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (AdditiveCritDamageBonus > 0)
            {
                modifiers.CritDamage += AdditiveCritDamageBonus;
            }
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (
                defendedByAbsorbTeamDamageEffect
                && Player == Main.LocalPlayer
                && TeammateCanAbsorbDamage()
            )
            {
                modifiers.FinalDamage *= 1f - AbsorbDamageStrength;
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            Player localPlayer = Main.LocalPlayer;
            if (
                defendedByAbsorbTeamDamageEffect
                && Player != localPlayer
                && IsClosestShieldWearerInRange(localPlayer, Player.position, Player.team)
            )
            {
                float percent = AbsorbDamageStrength;
                int damage = (int)(info.Damage * (percent / (1 - percent)));

                if (damage > 0)
                {
                    localPlayer.Hurt(PlayerDeathReason.LegacyEmpty(), damage, 0);
                }
            }
        }

        private bool TeammateCanAbsorbDamage()
        {
            foreach (var otherPlayer in Main.ActivePlayers)
            {
                if (
                    otherPlayer.whoAmI != Main.myPlayer
                    && IsAbleToAbsorbDamageForTeammate(otherPlayer, Player.team)
                )
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAbleToAbsorbDamageForTeammate(Player player, int team)
        {
            return player.active
                && !player.dead
                && player.GetModPlayer<DamageModificationPlayer>().hasAbsorbTeamDamageEffect
                && player.team == team
                && player.statLife
                    > player.statLifeMax2 * HolyPalladinHelmet.DamageAbsorptionAbilityLifeThreshold;
        }

        // This code finds the closest player wearing AbsorbTeamDamageAccessory.
        private static bool IsClosestShieldWearerInRange(Player player, Vector2 target, int team)
        {
            if (!IsAbleToAbsorbDamageForTeammate(player, team))
            {
                return false;
            }

            float distance = player.Distance(target);
            if (distance > HolyPalladinHelmet.DamageAbsorptionRange)
            {
                return false;
            }

            foreach (var otherPlayer in Main.ActivePlayers)
            {
                if (otherPlayer != player && IsAbleToAbsorbDamageForTeammate(otherPlayer, team))
                {
                    float otherPlayerDistance = otherPlayer.Distance(target);
                    if (
                        distance > otherPlayerDistance
                        || (distance == otherPlayerDistance && otherPlayer.whoAmI < Main.myPlayer)
                    )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
