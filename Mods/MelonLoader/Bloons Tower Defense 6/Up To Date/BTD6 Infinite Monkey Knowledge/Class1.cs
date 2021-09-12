using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using HarmonyLib;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
[assembly: MelonInfo(typeof(BTD6_Infinite_Monkey_Knowledge.Class1), "Infinite Monkey Knowledge", "2.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Infinite_Monkey_Knowledge
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt amount = new ModSettingInt(999999999);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Infinite Monkey Knowledge loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.KnowledgePoints = amount;
            }
        }
    }
}