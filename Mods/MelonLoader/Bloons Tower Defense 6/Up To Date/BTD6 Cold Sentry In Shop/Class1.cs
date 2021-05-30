using Assets.Main.Scenes;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Upgrade;
using Harmony;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System.IO;
[assembly: MelonInfo(typeof(BTD6_Cold_Sentry_In_Shop.Class1), "Cold Sentry In Shop", "1.3.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Cold_Sentry_In_Shop
{
    public class Class1 : MelonMod
    {
        public static string dir = $"{Directory.GetCurrentDirectory()}\\Mods\\ColdSentryInShop";
        public static string config = $"{dir}\\config.txt";
        public static int SentryColdCost = 500;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Cold Sentry In Shop mod loaded");
            Directory.CreateDirectory($"{dir}");
            if (File.Exists(config))
            {
                MelonLogger.Msg("Reading config file");
                using (StreamReader sr = File.OpenText(config))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        SentryColdCost = int.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                    }
                }
                MelonLogger.Msg("Done reading");
            }
            else
            {
                MelonLogger.Msg("Creating config file");
                using (StreamWriter sw = File.CreateText(config))
                {
                    sw.WriteLine("ColdSentryCost=500");
                }
                MelonLogger.Msg("Done Creating");
            }
        }
        [HarmonyPatch(typeof(ProfileModel), "Validate")]
        public class ProfileModel_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ProfileModel __instance)
            {
                HashSet<string> unlockedTowers = __instance.unlockedTowers;
                if (unlockedTowers.Contains("SentryCold"))
                {
                    MelonLogger.Msg("Cold Sentry already unlocked");
                }
                else
                {
                    MelonLogger.Msg("unlocking Cold Sentry");
                    unlockedTowers.Add("SentryCold");
                }
            }
        }
        [HarmonyPatch(typeof(TitleScreen), "UpdateVersion")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                TowerModel towerModel = Game.instance.model.GetTowerWithName("SentryCold");
                if (towerModel.icon == null)
                {
                    towerModel.icon = towerModel.portrait;
                }
                towerModel.cost = SentryColdCost;
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
            public static bool Prefix(ref List<TowerDetailsModel> allTowersInTheGame)
            {
                ShopTowerDetailsModel towerDetails = new ShopTowerDetailsModel("SentryCold", 1, 0, 0, 0, -1, 0, null);
                allTowersInTheGame.Add(towerDetails);
                return true;
            }
        }
        [HarmonyPatch(typeof(UpgradeScreen), "UpdateUi")]
        public class UpgradeScreen_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(ref string towerId)
            {
                if (towerId.Contains("SentryCold"))
                {
                    towerId = "DartMonkey";
                }
                return true;
            }
        }
    }
}