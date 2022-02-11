using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using Assets.Main.Scenes;
[assembly: MelonInfo(typeof(BTD6_Infinite_Monkey_Money.Main), "Infinite Monkey Money", "3.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Infinite_Monkey_Money
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingInt amount = new ModSettingInt(999999999);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Infinite Monkey Money loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.monkeyMoney.Value = amount;
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
    }
}