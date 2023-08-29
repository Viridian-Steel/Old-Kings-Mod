using Terraria.ModLoader;

namespace OldKings.Common.Players
{
    /// <summary>
    /// Registers all the keybings used for the mod. This is done cuz I would like a smooth load and unload sequence
    /// </summary>
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind DodgeKeybind { get; private set; }

        public override void Load()
        {
            DodgeKeybind = KeybindLoader.RegisterKeybind(Mod, "Augment:Dodge", Microsoft.Xna.Framework.Input.Keys.Q);
        }

    }
}
