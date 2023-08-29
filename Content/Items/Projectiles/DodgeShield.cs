using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;


namespace OldKings.Content.Items.Projectiles
{
    public class DodgeShield : ModProjectile
    {
        public float CollisionWidth => 10f * Projectile.scale;

        private int parryWindow = 5; // let's see how punishing this is

        public int Timer
        {
            get => (int)Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void SetStaticDefaults()
        {
            // crickets
        }

        public override void SetDefaults()
        {
            Projectile.Size = new Vector2(16, 32);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.scale = 1; // I think this is right?
            Projectile.timeLeft = 30; //0.3s is lenient, right?
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            player.heldProj = Projectile.whoAmI;

            // Keep locked onto the player, but extend further based on the given velocity (Requires ShouldUpdatePosition returning false to work)
            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
            Projectile.Center = playerCenter + Projectile.velocity * (Timer - 1f);

            Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

            // Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            FadeInAndOut();

        }

        private void SetVisualOffset()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            const int halfSpriteWidth = 8;
            const int halfSpriteHeight = 16;

            DrawOriginOffsetX = 0; // need to check this line
            DrawOffsetX = (halfSpriteWidth - halfProjWidth);
            DrawOriginOffsetY = (halfSpriteHeight - halfProjHeight);

        }

        public override bool ShouldUpdatePosition()
        {
            // Update Projectile.Center manually
            return false;
        }

        // Many projectiles fade in so that when they spawn they don't overlap the gun muzzle they appear from
        private void FadeInAndOut()
        {
            // If last less than 50 ticks — fade in, than more — fade out
            if (Projectile.ai[0] <= 50)
            {
                // Fade in
                Projectile.alpha -= 25;
                // Cap alpha before timer reaches 50 ticks
                if (Projectile.alpha < 100)
                    Projectile.alpha = 100;

                return;
            }

            // Fade out
            Projectile.alpha += 25;
            // Cal alpha to the maximum 255(complete transparent)
            if (Projectile.alpha > 255)
                Projectile.alpha = 255;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // "Hit anything between the player and the tip of the sword"
            // shootSpeed is 2.1f for reference, so this is basically plotting 12 pixels ahead from the center
            Vector2 start = Projectile.Center;
            Vector2 end = start + Projectile.velocity * 6f;
            float collisionPoint = 0f; // Don't need that variable, but required as parameter
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, CollisionWidth, ref collisionPoint);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) // maybe not the best
        {
            Player player = Main.player[Projectile.owner];
            if (Timer < parryWindow) { player.GetModPlayer<GlobalPlayer>().Parry(ref target, damage); }

            else player.GetModPlayer<GlobalPlayer>().Dodge();
        }


    }
}
