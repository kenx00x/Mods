using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using Il2CppAssets.Main.Scenes;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using MelonLoader;
using Main = BTD6_Infinite_Monkey_Knowledge.Main;

[assembly: MelonInfo(typeof(Main), "Infinite Monkey Knowledge", "3.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Infinite_Monkey_Knowledge
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingInt Amount = new ModSettingInt(999999999);

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Infinite Monkey Knowledge loaded!");
        }

        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class MainMenuPatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.KnowledgePoints = Amount;
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