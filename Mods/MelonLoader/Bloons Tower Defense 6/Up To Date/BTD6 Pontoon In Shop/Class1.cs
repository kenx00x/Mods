using Assets.Main.Scenes;
using Assets.Scripts.Models.Powers;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Pontoon_In_Shop.Class1), "Pontoon In Shop", "2.0.1", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Pontoon_In_Shop
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt price = new ModSettingInt(470);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Pontoon In Shop mod loaded");
        }
        [HarmonyPatch(typeof(ProfileModel), "Validate")]
        public class ProfileModel_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ProfileModel __instance)
            {
                HashSet<string> unlockedTowers = __instance.unlockedTowers;
                if (unlockedTowers.Contains("Pontoon"))
                {
                    MelonLogger.Msg("Pontoon already unlocked");
                }
                else
                {
                    MelonLogger.Msg("unlocking Pontoon");
                    unlockedTowers.Add("Pontoon");
                }
            }
        }
        [HarmonyPatch(typeof(TitleScreen), "UpdateVersion")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                PowerModel powerModel = Game.instance.model.GetPowerWithName("Pontoon");
                if (powerModel.tower.icon == null)
                {
                    powerModel.tower.icon = powerModel.icon;
                }
                powerModel.tower.cost = price;
                powerModel.tower.towerSet = "Support";
            }
        }
        [HarmonyPatch(typeof(TowerInventory), "Init")]
        public class TowerInventory_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
            {
                ShopTowerDetailsModel powerDetails = new ShopTowerDetailsModel("Pontoon", 1, 0, 0, 0, -1, 0, null);
                allTowersInTheGame.Add(powerDetails);
            }
        }
        [HarmonyPatch(typeof(UpgradeScreen), "UpdateUi")]
        public class UpgradeScreen_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(ref string towerId)
            {
                if (towerId.Contains("Pontoon"))
                {
                    towerId = "DartMonkey";
                }
            }
        }
    }
}