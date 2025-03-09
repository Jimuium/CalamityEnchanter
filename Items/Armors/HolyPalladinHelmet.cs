using System;
using CalamityEnchanter.Buffs;
using CalamityEnchanter.Common.DamageClasses;
using CalamityEnchanter.Common.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class HolyPalladinHelmet : ModItem
    {
        readonly float DamageIncrease = 0.10f;
        readonly float ResourceIncrease = 0.6f;

        //set bonut
        readonly float SetBonusDamageIncrease = 0.4f;
        readonly float regenIncrease = 1.2f;
        readonly int maxResourceIncrease = 80;
        readonly float BuffLengthIncrease = 0.3f;
        readonly float otherRegenDecrease = 0.3f;
        readonly float otherBuffDecrease = 0.5f;
        public static float DamageAbsorptionAbilityLifeThreshold = 0.25f;
        public static int DamageAbsorptionRange = 1600;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<HolyHexDamageClass>()) += DamageIncrease;
            var HolyPoolPlayer = player.GetModPlayer<HolyPoolPlayer>();
            HolyPoolPlayer.HolyPoolRegenRate += ResourceIncrease;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HolyPalladinBreastplate>()
                && legs.type == ModContent.ItemType<HolyPalladinLeggins>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus =
                $"Increases Holy Damage by {Math.Round(SetBonusDamageIncrease * 100, 1)
                }%\nIncreases Holy regen by {Math.Round(regenIncrease * 100, 1)}% and Max Holy by {maxResourceIncrease
                }\nIncreases Holy buff length by {Math.Round(BuffLengthIncrease * 100, 1)
                }% But Decreases Other types of buffs by {Math.Round(otherBuffDecrease * 100, 1)
                }&\nDecreases Fury and agility regeneration by {Math.Round(otherRegenDecrease * 100, 1)}%";
            player.GetDamage(ModContent.GetInstance<HolyHexDamageClass>()) +=
                SetBonusDamageIncrease;
            var HolyPoolPlayer = player.GetModPlayer<HolyPoolPlayer>();
            HolyPoolPlayer.HolyPoolRegenRate += regenIncrease;
            HolyPoolPlayer.HolyPoolMax2 += maxResourceIncrease;
            HolyPoolPlayer.HolyBuffLengthMultiplier += BuffLengthIncrease;

            var FuryEnergyPlayer = player.GetModPlayer<FuryEnergyPlayer>();
            FuryEnergyPlayer.FuryEnergyRegenRate -= otherRegenDecrease;
            FuryEnergyPlayer.FuryBuffLengthMultiplier -= otherBuffDecrease;

            var CalmAgilityPlayer = player.GetModPlayer<CalmAgilityPlayer>();
            CalmAgilityPlayer.CalmAgilityRegenRate -= otherRegenDecrease;
            CalmAgilityPlayer.AgilityBuffLengthMultiplier -= otherBuffDecrease;
            player.GetModPlayer<DamageModificationPlayer>().hasAbsorbTeamDamageEffect = true;

            if (player.whoAmI != Main.myPlayer && player.miscCounter % 10 == 0)
            {
                foreach (Player target in Main.player)
                {
                    if (
                        target != player
                        && target.team == player.team
                        && player.team != 0
                        && player.statLife
                            > player.statLifeMax2 * DamageAbsorptionAbilityLifeThreshold
                        && player.Distance(target.Center) <= DamageAbsorptionRange
                    )
                    {
                        target.AddBuff(ModContent.BuffType<HolyPalladinArmorBuff>(), 20);
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe().Register();
        }
    }
}
