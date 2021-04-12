using ModSettings;
using UnityEngine;

namespace CraftingHotkey
{
	internal class CraftingHotkeySettings : JsonModSettings
	{
		[Name("Key for the Crafting Menu")]
		[Description("The key you press to show the crafting menu.")]
		public KeyCode keyCode = KeyCode.T;
	}
	internal static class Settings
	{
		internal static CraftingHotkeySettings options;

		public static void OnLoad()
		{
			options = new CraftingHotkeySettings();
			options.AddToModSettings("Crafting Hotkey");
		}
	}
}
