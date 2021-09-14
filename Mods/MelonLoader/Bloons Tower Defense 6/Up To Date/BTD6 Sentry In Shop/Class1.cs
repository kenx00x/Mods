using Assets.Main.Scenes;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Sentry_In_Shop.Class1), "Sentry In Shop", "2.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Sentry_In_Shop
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt price = new ModSettingInt(100);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Sentry In Shop mod loaded");
        }
        [HarmonyPatch(typeof(ProfileModel), "Validate")]
        public class ProfileModel_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ProfileModel __instance)
            {
                HashSet<string> unlockedTowers = __instance.unlockedTowers;
                if (unlockedTowers.Contains("Sentry"))
                {
                    MelonLogger.Msg("Sentry already unlocked");
                }
                else
                {
                    MelonLogger.Msg("unlocking Sentry");
                    unlockedTowers.Add("Sentry");
                }
            }
        }
        [HarmonyPatch(typeof(TitleScreen), "UpdateVersion")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                TowerModel towerModel = Game.instance.model.GetTowerWithName("Sentry");
                if (towerModel.icon == null)
                {
                    towerModel.icon = towerModel.portrait;
                }
                towerModel.cost = price;
                towerModel.towerSet = "Support";
                towerModel.radius = 6;
                towerModel.radiusSquared = 36;
                towerModel.footprint.doesntBlockTowerPlacement = false;
                List<Model> temp = new List<Model>();
                for (int i = 0; i < towerModel.behaviors.Length; i++)
                {
                    if (towerModel.behaviors[i].name != "TowerExpireModel_")
                    {
                        temp.Add(towerModel.behaviors[i]);
                    }
                }
                towerModel.behaviors = (UnhollowerBaseLib.Il2CppReferenceArray<Model>)temp.ToArray();
            }
        }
        [HarmonyPatch(typeof(TowerInventory), "Init")]
        public class TowerInventory_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
            {
                ShopTowerDetailsModel towerDetails = new ShopTowerDetailsModel("Sentry", 1, 0, 0, 0, -1, 0, null);
                allTowersInTheGame.Add(towerDetails);
            }
        }
        [HarmonyPatch(typeof(UpgradeScreen), "UpdateUi")]
        public class UpgradeScreen_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(ref string towerId)
            {
                if (towerId.Contains("Sentry"))
                {
                    towerId = "DartMonkey";
                }
            }
        }
    }
}