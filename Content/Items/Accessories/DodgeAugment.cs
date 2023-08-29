using OldKings.Content.Tiles.Furniture;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using OldKings.Content.DamageClasses;
using OldKings.Content.Items.Placeable;
using Microsoft.Xna.Framework.Content;
using OldKings.Common.Players;
using Terraria.DataStructures;
using System;
using Terraria.GameInput;

namespace OldKings.Content.Items.Accessories
{
    public class DodgeAugment : ModItem
    {
        public override void SetStaticDefaults()
        {
            //No Name setting might fix this? Nope
            Tooltip.SetDefault("Parry this you filthy casual."); // waay too long

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;

            Item.value = 500;
            Item.rare = ItemRarityID.Master;

            Item.accessory = true;

            //Item.defense = 20;
            

        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetDamage(ModContent.GetInstance<Auric>()) += 2f; // auric go BRRRRRRR
            //was it endurance? NOpe
            player.GetModPlayer<GlobalPlayer>().HasDodgeAugment = true;
            //player.GetModPlayer<GlobalPlayer>().MartialBonus = 20; // is it this?

        }

        
        // It isn't this
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.AdamantiteBar, 15);
            recipe.AddIngredient(ModContent.ItemType<UraniumOre>(), 15);
            recipe.AddTile(ModContent.TileType<SimpleAssembler>());
            recipe.Register();
        }

    }


}

