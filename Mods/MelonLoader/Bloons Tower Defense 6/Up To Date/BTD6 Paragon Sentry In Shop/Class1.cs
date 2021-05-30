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
[assembly: MelonInfo(typeof(BTD6_Paragon_Sentry_In_Shop.Class1), "Paragon Sentry In Shop", "1.0.1", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Paragon_Sentry_In_Shop
{
    public class Class1 : MelonMod
    {
        public static string dir = $"{Directory.GetCurrentDirectory()}\\Mods\\ParagonSentryInShop";
        public static string config = $"{dir}\\config.txt";
        public static int SentryParagonCost = 5000;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Paragon Sentry In Shop mod loaded");
            Directory.CreateDirectory($"{dir}");
            if (File.Exists(config))
            {
                MelonLogger.Msg("Reading config file");
                using (StreamReader sr = File.OpenText(config))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        SentryParagonCost = int.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                    }
                }
                MelonLogger.Msg("Done reading");
            }
            else
            {
                MelonLogger.Msg("Creating config file");
                using (StreamWriter sw = File.CreateText(config))
                {
                    sw.WriteLine("ParagonSentryCost=5000");
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
                if (unlockedTowers.Contains("SentryParagon"))
                {
                    MelonLogger.Msg("Paragon Sentry already unlocked");
                }
                else
                {
                    MelonLogger.Msg("unlocking Paragon Sentry");
                    unlockedTowers.Add("SentryParagon");
                }
            }
        }
        [HarmonyPatch(typeof(TitleScreen), "UpdateVersion")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                TowerModel towerModel = Game.instance.model.GetTowerWithName("SentryParagon");
                if (towerModel.icon == null)
                {
                    towerModel.icon = towerModel.portrait;
                }
                towerModel.cost = SentryParagonCost;
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
                ShopTowerDetailsModel towerDetails = new ShopTowerDetailsModel("SentryParagon", 1, 0, 0, 0, -1, 0, null);
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
                if (towerId.Contains("SentryParagon"))
                {
                    towerId = "DartMonkey";
                }
                return true;
            }
        }
    }
}