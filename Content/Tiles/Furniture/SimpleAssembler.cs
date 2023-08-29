using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace OldKings.Content.Tiles.Furniture
{
    public class SimpleAssembler : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;


            TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
            TileObjectData.newTile.Width = 6;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0,2);
            //We'll see how not adding Coordinate Heights will go
            TileObjectData.newTile.CoordinatePadding = 2;
            //Same with Anchoring. It went fine

            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable); // cuz why not

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Simple Assembler");
            AddMapEntry(Color.White, name);

        }
        public override void NumDust(int x, int y, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 96, 48, ModContent.ItemType<Items.Placeable.Furniture.SimpleAssembler>());
        }
    }
}
