using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;

namespace OldKings.Content.Items.Placeable.Furniture
{
    public class SimpleAssembler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Simple Assembler");
            Tooltip.SetDefault("This can be repaired, but not with your knowledge");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tiles.Furniture.SimpleAssembler>();

            Item.width = 96;
            Item.height = 48;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15; // frame time
            Item.consumable = true;
            Item.maxStack = 99;

            Item.value = 100;

        }

        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

    }
}
