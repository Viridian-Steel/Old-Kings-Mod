using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OldKings.Content.DamageClasses
{
    /// <summary>
    /// 
    /// Class <c>Auric</c> describes the interation between this damage model and other damage models
    /// 
    /// </summary>
    public class Auric : DamageClass
    {

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if(damageClass == DamageClass.Generic) return StatInheritanceData.Full;

            return StatInheritanceData.None;
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if(damageClass == DamageClass.Magic) return true;
            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetArmorPenetration<Auric>() += 5;
        }

        //public override bool UseStandardCritCalcs => true;

        public override bool ShowStatTooltipLine(Player player, string lineName)
        {
            if(lineName == "speed") return false;
            return true;
        }

        
    }
}
