using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CalamityEnchanter.Items
{
    internal class ExampleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //research amount?
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.value = Item.buyPrice(silver: 2, copper: 40);
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            CreateRecipe().Register();
        }
    }
} 