using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using OldKings.Common.Players;
using Terraria.GameInput;
using Microsoft.Xna.Framework;

namespace OldKings
{


    /// <summary>
    /// <c>GlobalPlayer</c> stores many of the variables that this mod needs to work.
    /// </summary>
    public class GlobalPlayer : ModPlayer
    {
        public int GeneralTech  { get; set; }
        public int AuricTech    { get; set; }
        public int ShadicTech   { get; set; }
        public int WarTech      { get; set; }
        public int TameTech     { get; set; }
        public int TyrantTech   { get; set; }
        public int MartialTech  { get; set; }


        public int MartialBonus { get; set; }
        public int AuricBonus   { get; set; }
        public int TameBonus    { get; set; }
        
        public bool HasDodgeAugment { get; set; }

        public const int DodgeCoolDown = 120;
        public const int ParryCoolDown = 5;

        public int cooldown = 0; // dodge and parry share the same cooldown

        public void Dodge()
        {
            if (!HasDodgeAugment || cooldown != 0) { return; }
            Player.ShadowDodge();
            Player.AddImmuneTime(ImmunityCooldownID.General, 20); //20 frames of sweet dodge action
            cooldown = DodgeCoolDown;
            CombatText.clearAll();
            CombatText.NewText(new Microsoft.Xna.Framework.Rectangle((int)Player.position.X, (int)Player.position.Y + 16, 32, 16), Color.Maroon, "Dodge!", true);
            
        }
        

        public void Parry(ref NPC target, int originaldamage)
        {
            if (!HasDodgeAugment || cooldown != 0) { return; }
            int dir = 0;
            if( Player.DirectionTo(target.position).X > 0 ) { dir = 1; }
            else { dir = -1; }
            Player.ShadowDodge();
            Player.AddImmuneTime(ImmunityCooldownID.General, 60); // the reward
            Player.ApplyDamageToNPC(target, originaldamage * MartialBonus, 0, dir, true);
            cooldown = ParryCoolDown;
            //Main.NewText("PARRY!");
            CombatText.clearAll();
            CombatText.NewText(new Microsoft.Xna.Framework.Rectangle((int)Player.position.X, (int)Player.position.Y + 16, 32, 16), Color.Maroon, "Parry!", true);
        }

        public override void PostUpdate()
        {
            cooldown = cooldown > 0 ? cooldown-- : 0;
        }

    }
}
