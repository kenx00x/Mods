using MelonLoader;
using Assets.Scripts.Unity;
using HarmonyLib;
using Assets.Scripts.Unity.UI_New.Main;
[assembly: MelonInfo(typeof(BTD6_Unlock_Big_Bloons.Class1), "Unlock Big Bloons", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Unlock_Big_Bloons
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Unlock Big Bloons loaded");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.unlockedBigBloons = true;
            }
        }
    }
}