using Assets.Main.Scenes;
using Assets.Scripts.Data;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Main = BTD6_All_Trophy_Store_Items_Unlocker.Main;

[assembly: MelonInfo(typeof(Main), "All Trophy Store Items Unlocker", "4.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6_All_Trophy_Store_Items_Unlocker
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("All Trophy Store Items Unlocker loaded!");
        }

        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreenPatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                var testList = new List<string>();
                foreach (var item in Game.instance.playerService.Player.Data.trophyStorePurchasedItems)
                    testList.Add(item.Key);
                foreach (var item in GameData._instance.trophyStoreItems.storeItems)
                {
                    if (testList.Contains(item.id)) continue;
                    Game.instance.playerService.Player.AddTrophyStoreItem(item.id);
                    MelonLogger.Msg($"Unlocked {item.id}");
                }
            }
        }

        [HarmonyPatch(typeof(InitialLoadingScreen), "Update")]
        public class InitialLoadingScreenPatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Modding.isModdedClient = false;
            }
        }
        [HarmonyPatch(typeof(Modding), "CheckForMods")]
        public class ModdingPatch
        {
            [HarmonyPostfix]
            public static bool Prefix(ref bool __result)
            {
                __result = false;
                return false;
            }
        }
        [HarmonyPatch(typeof(Modding), "IsModdingLibrary")]
        public class ModdingPatch2
        {
            [HarmonyPostfix]
            public static bool Prefix(ref bool __result)
            {
                __result = false;
                return false;
            }
        }
    }
}