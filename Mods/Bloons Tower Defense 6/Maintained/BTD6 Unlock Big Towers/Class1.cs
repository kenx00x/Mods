using MelonLoader;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Main;

[assembly: MelonInfo(typeof(BTD6_Unlock_Big_Towers.Class1), "Unlock Big Towers", "1.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Unlock_Big_Towers
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Unlock Big Towers loaded");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.unlockedBigTowers = true;
            }
        }
    }
}