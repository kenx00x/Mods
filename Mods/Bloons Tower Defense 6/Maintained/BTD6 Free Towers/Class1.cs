using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Map;
using MelonLoader;
using SimHero = Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Hero;
using SimTowerManager = Il2CppAssets.Scripts.Simulation.Towers.TowerManager;

[assembly: MelonInfo(typeof(freeTowers.Class1), "free towers and upgrades", "2.1.1", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi")]

namespace freeTowers
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt towerCost = new ModSettingInt(0);
        public static ModSettingInt upgradeCost = new ModSettingInt(0);
        public static ModSettingDouble heroUpgradeCost = new ModSettingDouble(0);

        static bool buyingHeroLevel;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Free towers and upgrades mod loaded");
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

                    if (tower.IsHero())
                    {
                        var heroModel = tower.GetHeroModel();
                        if (heroModel != null) heroModel.costPerXpToLevel = 0f;
                    }
                }

                foreach (UpgradeModel upgrade in Game.instance.model.upgrades)
                {
                    upgrade.cost = upgradeCost;
                }
            }
        }

        [HarmonyPatch(typeof(SimHero), "GetCostToLevelUp")]
        public class HeroCost_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ref float __result)
            {
                __result = (float)(double)heroUpgradeCost;
            }
        }

        [HarmonyPatch(typeof(SimHero), "PurchaseHeroLevelUp")]
        public class HeroPurchase_Patch
        {
            [HarmonyPrefix]
            public static void Prefix()
            {
                buyingHeroLevel = true;
            }

            [HarmonyFinalizer]
            public static void Finalizer()
            {
                buyingHeroLevel = false;
            }
        }

        [HarmonyPatch(typeof(SimTowerManager), "UpgradeTower")]
        public class UpgradeTower_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(ref float upgradeCost)
            {
                if (buyingHeroLevel) upgradeCost = (float)heroUpgradeCost;
            }
        }
    }
}