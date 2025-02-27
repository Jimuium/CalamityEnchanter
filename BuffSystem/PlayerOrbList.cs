using System.Collections.Generic;
using System.Linq;
using CalamityEnchanter.DamageClasses;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Buffsystem
{
    public class PlayerOrbStats : ModPlayer
    {
        public Dictionary<string, Bonus> PlayerBonus = new Dictionary<string, Bonus>();

        public override void PostUpdate()
        {
            foreach (var key in PlayerBonus.Keys.ToList())
            {
                var bonus = PlayerBonus[key];

                if (!bonus.IsActive)
                {
                    bonus.IsActive = true;
                    switch (key)
                    {
                        case "DefenceUp":
                            Player.statDefense += bonus.Amount;
                            break;
                        case "LifeRegenUp":
                            Player.lifeRegen += bonus.Amount;
                            break;
                        case "HexDmgMutliplier":
                            Player.GetDamage(ModContent.GetInstance<HexDamageClass>()) +=
                                bonus.Amount;
                            break;
                        case "MoveSpeedMutl":
                            Player.moveSpeed += bonus.Amount;
                            break;
                    }
                }
                bonus.Duration--;

                if (bonus.Duration <= 0)
                {
                    PlayerBonus.Remove(key);
                }
            }
        }
    }

    public class Bonus
    {
        public int Amount { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

        public Bonus(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
            IsActive = false;
        }
        /*
        full usage. use when player should get the buff: 
        player.GetModPlayer<PlayerOrbStats>().PlayerBonus["DefenceUp"] = new Bonus(10, 600);
        
        */
    }
}
