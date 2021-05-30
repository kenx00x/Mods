using Assets.Scripts.Data;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_All_Trophy_Store_Items_Unlocker.Class1), "All Trophy Store Items Unlocker", "1.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_All_Trophy_Store_Items_Unlocker
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("All Trophy Store Items Unlocker loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                List<string> testList = new List<string>();
                foreach (var item in Game.instance.playerService.Player.Data.trophyStorePurchasedItems)
                {
                    testList.Add(item.Key);
                }
                foreach (var item in GameData._instance.trophyStoreItems.storeItems)
                {
                    if (!testList.Contains(item.id))
                    {
                        Game.instance.playerService.Player.AddTrophyStoreItem(item.id);
                        MelonLogger.Msg($"Unlocked {item.id}");
                    }
                }
            }
        }
    }
}