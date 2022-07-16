using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;
using Main = BTD6_All_The_Towers_In_Shop.Main;

[assembly: MelonInfo(typeof(Main), "All The Towers In Shop", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6_All_The_Towers_In_Shop
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt BananaFarmerPrice = new ModSettingInt(550);
        public static readonly ModSettingInt CaveMonkeyPrice = new ModSettingInt(250);
        public static readonly ModSettingInt BoomSentryPrice = new ModSettingInt(500);
        public static readonly ModSettingInt ColdSentryPrice = new ModSettingInt(500);
        public static readonly ModSettingInt CrushingSentryPrice = new ModSettingInt(500);
        public static readonly ModSettingInt EnergySentryPrice = new ModSettingInt(500);
        public static readonly ModSettingInt ParagonSentryPrice = new ModSettingInt(5000);
        public static readonly ModSettingInt SentryPrice = new ModSettingInt(100);
        public static readonly ModSettingInt TechBotPrice = new ModSettingInt(500);
        public static readonly ModSettingInt EnergisingTotemPrice = new ModSettingInt(630);
        public static readonly ModSettingInt MarinePrice = new ModSettingInt(135000);
        public static readonly ModSettingInt PontoonPrice = new ModSettingInt(470);
        public static readonly ModSettingInt PortableLakePrice = new ModSettingInt(470);
        public static readonly ModSettingInt MiniSunAvatarPrice = new ModSettingInt(150000);
        public static readonly ModSettingInt ShootyTurretTowerV2Price = new ModSettingInt(1000);
        public static readonly ModSettingInt ShootyTurretTowerPrice = new ModSettingInt(250);
        public static readonly ModSettingInt TransFormedBaseMonkeyPrice = new ModSettingInt(7000);

        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("All The Towers In Shop mod loaded");
        }
        //[HarmonyPatch(typeof(MainMenu), "Open")]
        //public class TitleScreenPatch
        //{
        //    [HarmonyPostfix]
        //    public static void Postfix()
        //    {
        //        foreach (var tower in Game.instance.model.towers)
        //        {
        //            MelonLogger.Msg(tower.name);
        //        }
        //    }
        //}
    }
}    