using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityEnchanter.Common.Systems
{
    public class GreenDyeRecipeGroup : ModSystem
    {
        public static RecipeGroup MyCustomGroup;

        public override void AddRecipeGroups()
        {
            // Array of item IDs that belong to this group
            int[] items =
            {
                ItemID.GreenDye,
                ItemID.LimeDye,
                ItemID.TealDye,
                ItemID.GreenFlameDye,
                ItemID.IntenseGreenFlameDye,
                ItemID.BrightGreenDye,
                ItemID.GreenandBlackDye,
                ItemID.GreenandSilverDye,
                ItemID.GreenFlameDye,
                ItemID.IntenseGreenFlameDye,
                ItemID.BrightLimeDye,
                ItemID.LimeandBlackDye,
                ItemID.LimeandSilverDye,
                ItemID.BrightTealDye,
                ItemID.ChlorophyteDye,
                ItemID.ReflectiveDye,
                ItemID.GrimDye,
                ItemID.MirageDye,
            };

            // Create the RecipeGroup
            MyCustomGroup = new RecipeGroup(
                () => $"Any dye with a hint of green dye will do", // Display name
                items
            );

            // Register the group with a unique name
            RecipeGroup.RegisterGroup("greenDyes", MyCustomGroup);
        }
    }
}
