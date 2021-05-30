using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Harmony;
using MelonLoader;
using System.IO;
[assembly: MelonInfo(typeof(freeTowers.Class1), "free towers and upgrades", "1.3.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace freeTowers
{
    public class Class1 : MelonMod
    {
        public static string dir = $"{Directory.GetCurrentDirectory()}\\Mods\\FreeTowersAndUpgrades";
        public static string config = $"{dir}\\config.txt";
        public static int towerCost = 0;
        public static int upgradeCost = 0;
        public static float heroUpgradeCost = 0;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Free towers and upgrades mod loaded");
            Directory.CreateDirectory($"{dir}");
            if (File.Exists(config))
            {
                MelonLogger.Msg("Reading config file");
                using (StreamReader sr = File.OpenText(config))
                {
                    int line = 0;
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        switch (line)
                        {
                            case 0:
                                towerCost = int.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                            case 1:
                                upgradeCost = int.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                            case 2:
                                heroUpgradeCost = float.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1)) / 1000;
                                break;
                        }
                        line++;
                    }
                }
                MelonLogger.Msg("Done reading");
            }
            else
            {
                MelonLogger.Msg("Creating config file");
                using (StreamWriter sw = File.CreateText(config))
                {
                    sw.WriteLine("BaseTowerCost=0");
                    sw.WriteLine("BaseUpgradeCost=0");
                    sw.WriteLine("BaseHeroUpgradeCost=0");
                }
                MelonLogger.Msg("Done Creating");
            }
        }
        [HarmonyPatch(typeof(TowerSelectionMenu), "UpdateHeroBooster")]
        public class FreeHeroUpgrade_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(TowerToSimulation tower)
            {
                tower.hero.hero.heroModel.costPerXpToLevel = heroUpgradeCost;
            }
        }
        [HarmonyPatch(typeof(MapLoader), "Load")]
        public class MapLoader_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (TowerModel tower in Game.instance.model.towers)
                {
                    tower.cost = towerCost;
                }
                foreach (UpgradeModel upgrade in Game.instance.model.upgrades)
                {
                    upgrade.cost = upgradeCost;
                }
            }
        }
    }
}