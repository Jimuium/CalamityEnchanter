using System.Linq;
using CalamityEnchanter.Items.Accessories;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

public class JungleEnemyDrops : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        int itemType = ModContent.ItemType<HealingSpirit>();

        int[] jungleEnemies = new int[]
        {
            NPCID.GiantFlyingFox,
            NPCID.GiantTortoise,
            NPCID.AngryTrapper,
            NPCID.Derpling,
            NPCID.Arapaima,
        };

        if (jungleEnemies.Contains(npc.type))
        {
            IItemDropRule hardmodeDrop = new LeadingConditionRule(new HardmodeCondition());

            hardmodeDrop.OnSuccess(ItemDropRule.Common(itemType, chanceDenominator: 100));

            npcLoot.Add(hardmodeDrop);
        }
    }
}

public class HardmodeCondition : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return Main.hardMode;
    }

    public bool CanShowItemDropInUI()
    {
        return true;
    }

    public string GetConditionDescription()
    {
        return "Drops in Hardmode";
    }
}
