using Microsoft.Xna.Framework;
using OldKings.Content.DamageClasses;
using OldKings.Content.Items.Projectiles;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace OldKings.Content.Items.Weapons
{
    public class DodgeAbility : ModItem
    {
        public bool altHit = false;
        public bool attemptAltHit = false;

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<Martial>();
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Rapier; 
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.damage = 100;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item1;//not even sure what that is
            Item.autoReuse = true;
            Item.noUseGraphic = true; // use projectile
            Item.noMelee = true; //projectile does damage

            Item.rare = ItemRarityID.Master;
            Item.value = Item.sellPrice(platinum: 1);

            Item.shoot = ModContent.ProjectileType<TestProjectile>();
            Item.shootSpeed = 2; // it's a fast mofo

        }

        public override bool AltFunctionUse(Player player) { return true; }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if( player.altFunctionUse == 2) { type = ModContent.ProjectileType<DodgeShield>(); }
        }

    }
}
