using OldKings.Content.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using OldKings.Content.DamageClasses;

namespace OldKings.Content.Items.Projectiles
{
    public class TestProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new Vector2(64, 14);
            Projectile.width = 64;
            Projectile.height = 40;

            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<Martial>();
            Projectile.ignoreWater = false;
            Projectile.ownerHitCheck = true;
            Projectile.penetrate = 3;

            Projectile.alpha = 255; //starts fully transparent;

            Projectile.timeLeft = 30; // 30 frames of life
            
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * Projectile.Opacity;
        }

        public override void AI()
        {
            

            Projectile.ai[0] += 1;
            FadeInAndOut();

            //projectile doesn't slow down currently
            if(++Projectile.frameCounter >= 5)
            {
                Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
            }


        }

        // Many projectiles fade in so that when they spawn they don't overlap the gun muzzle they appear from
        public void FadeInAndOut()
        {
            // If last less than 50 ticks — fade in, than more — fade out
            if (Projectile.ai[0] <= 50f)
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

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if(Projectile.direction == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Projectile.type], frameY: Projectile.frame);

            Vector2 origin = sourceRectangle.Size() / 2f;

            float offsetX = 20f;
            origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);

            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            // It's important to return false, otherwise we also draw the original texture.
            return false;

        }


    }
}
