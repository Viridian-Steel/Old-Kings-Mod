using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace OldKings.Content.Tiles.Ores
{
    public class Uranium : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 710;
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Uranium Ore");
            AddMapEntry(Color.Green, name);

            DustType = 84;
            ItemDrop = ModContent.ItemType<Items.Placeable.UraniumOre>();
            HitSound = SoundID.Tink;

        }

        public override void FloorVisuals(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Parasitized>(), 2);
        }

    }

    //Including the MapGen Pass and ModSystem for the ore here Feels like a good way to get lost. just keep to the conventions, i guess
    public class UraniumOrePass : GenPass {
        public UraniumOrePass(string name, float loadweight) : base(name, loadweight) {}

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding Uranium";

            for(int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Uranium>());
            }

        }

    }

    public class UraniumOreSystem : ModSystem {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shineIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if(shineIndex !=  -1)
            {
                tasks.Insert(shineIndex + 1, new UraniumOrePass("Uranium Ores", 500)); //TODO: Modify this number
            }

        }
    }


}
