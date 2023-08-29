using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OldKings.Content.DamageClasses
{
    public class Martial : DamageClass
    {

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if(damageClass == DamageClass.Melee || damageClass == DamageClass.Generic)
            {
                return StatInheritanceData.Full;
            }
            return StatInheritanceData.None;
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Melee) return true;
            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetArmorPenetration<Martial>() += 15; //insane armour penetration
        }


    }
}
