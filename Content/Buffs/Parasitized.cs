using Terraria;
using Terraria.ModLoader;


namespace OldKings.Content.Buffs
{
    public class Parasitized : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Parasitized");
            Description.SetDefault("You should probably get that checked out");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ParasitizedPlayer>().parasitized = true;
        }
    }

    public class ParasitizedPlayer : ModPlayer
    {
        public bool parasitized = false;

        public override void ResetEffects() { parasitized = false; }

        public override void UpdateBadLifeRegen()
        {
            if( parasitized )
            {
                if (Player.lifeRegen > 0) Player.lifeRegen = 0;
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 32;
            }
        }
    }

}
