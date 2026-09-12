using System.Collections.Generic;
using HarmonyLib;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using MelonLoader;
using Main = BTD6_All_Trophy_Store_Items_Unlocker.Main;

[assembly: MelonInfo(typeof(Main), "All Trophy Store Items Unlocker", "4.5.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi")]

namespace BTD6_All_Trophy_Store_Items_Unlocker
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
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
    }
}