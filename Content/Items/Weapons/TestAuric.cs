using OldKings.Content.DamageClasses;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace OldKings.Content.Items.Weapons
{

    public class TestAuric : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            
        }


        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<Auric>();
            Item.width = 48;
            Item.height = 64;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = true;
            Item.damage = 999;
            Item.knockBack = 1;
            Item.crit = 50;
            Item.mana = 150;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item71;
            Item.shoot = ProjectileID.BlackBolt;
            Item.shootSpeed = 15;
            Item.value = 10000;


        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var dmgLine = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if(dmgLine != null)
            {
                string[] split = dmgLine.Text.Split(" ");
                dmgLine.Text = split.First() + " Auric Damage"; //It works

            }

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }

    }
}
