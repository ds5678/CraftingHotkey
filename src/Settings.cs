using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;
using UnityEngine;

namespace CraftingHotkey
{
    internal enum KeyCodeAlphabet
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }
    internal class Settings : JsonModSettings
    {
        [Name("Key for the Crafting Menu")]
        [Description("The key you press to show the crafting menu.")]
        public KeyCodeAlphabet keyCodeAlphabet = KeyCodeAlphabet.T;

        protected override void OnConfirm()
        {
            base.OnConfirm();
            CraftingHotkeySettings.keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeAlphabet.ToString());
        }
    }
    internal static class CraftingHotkeySettings
    {
        internal static readonly Settings settings = new Settings();
        internal static KeyCode keyCode;

        public static void OnLoad()
        {
            settings.AddToModSettings("Crafting Hotkey");
            keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), settings.keyCodeAlphabet.ToString());
        }
    }
}
