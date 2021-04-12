using Harmony;
using MelonLoader;
using UnityEngine;

namespace CraftingHotkey
{
	public class Implementation : MelonMod
	{
		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
			Settings.OnLoad();
		}

		public static void MaybeShowCraftingMenu()
		{
			if (InputManager.GetKeyDown(InputManager.m_CurrentContext, Settings.options.keyCode))
			{
				Panel_Crafting craftingPanel = InterfaceManager.m_Panel_Crafting;
				if (craftingPanel == null || uConsole.IsOn()) return;
				if (craftingPanel.IsEnabled() && !craftingPanel.m_CraftingInProgress)
				{
					craftingPanel.OnBackButton();
					return;
				}
				else
				{
					Panel_FirstAid firstAid = InterfaceManager.m_Panel_FirstAid;
					if (firstAid != null && firstAid.IsEnabled())
					{
						firstAid.OnCraftingNav();
						return;
					}
					Panel_Clothing clothing = InterfaceManager.m_Panel_Clothing;
					if (clothing != null && clothing.IsEnabled())
					{
						clothing.OnCraftingNav();
						return;
					}
					Panel_Inventory inventory = InterfaceManager.m_Panel_Inventory;
					if (inventory != null && inventory.IsEnabled())
					{
						inventory.OnCraftingNav();
						return;
					}
					Panel_Log journal = InterfaceManager.m_Panel_Log;
					if (journal != null && journal.IsEnabled() && journal.m_ReadyForInput)
					{
						journal.OnCraftingNav();
						return;
					}
					Panel_Map map = InterfaceManager.m_Panel_Map;
					if (map != null && (map.IsEnabled() || !InterfaceManager.IsOverlayActiveImmediate()))
					{
						map.OnCraftingNav();
						return;
					}
				}
			}
		}
	}

	[HarmonyPatch(typeof(GameManager), "Update")]
	internal class GameManager_Update
	{
		private static void Postfix()
		{
			Implementation.MaybeShowCraftingMenu();
		}
	}
}
