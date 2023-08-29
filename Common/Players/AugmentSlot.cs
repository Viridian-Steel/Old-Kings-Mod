using OldKings.Content.Items.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace OldKings.Common.Players
{
    /// <summary>
    /// <c>AugmentSlot</c> is the special slot for augments only.
    /// </summary>
    public class AugmentSlot : ModAccessorySlot
    {
        public override string FunctionalBackgroundTexture => OldKings.ASSET_PATH + "Textures/AccessorySlots/TechBase.png";

        public override string FunctionalTexture => OldKings.ASSET_PATH + "Textures/AccessorySlots/AugmentBackGround.png";

        private static bool IsAugment(Item checkItem) { return checkItem.accessory && checkItem.type == ModContent.ItemType<DodgeAugment>(); } // will need to change later. But that's not the augment problem

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) { return IsAugment(checkItem); }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) { return IsAugment(item); }

    }

    

}
