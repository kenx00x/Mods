using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Max_Player_level.Class1), "Max Player Level", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Max_Player_level
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingDouble xp = new ModSettingDouble(999999999);
        public static ModSettingDouble VeteranXp = new ModSettingDouble(999999999);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Max Player Level loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.xp.Value = xp;
                Game.instance.playerService.Player.Data.veteranXp.Value = VeteranXp;
                Game.instance.playerService.Player.CheckAndCorrectLevelBasedOnPlayerXp();
            }
        }
    }
}