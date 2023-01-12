using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Map;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using MelonLoader;
[assembly: MelonInfo(typeof(freeTowers.Class1), "free towers and upgrades", "2.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace freeTowers
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt towerCost = new ModSettingInt(0);
        public static ModSettingInt upgradeCost = new ModSettingInt(0);
        public static ModSettingDouble heroUpgradeCost = new ModSettingDouble(0);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Free towers and upgrades mod loaded");
        }
        [HarmonyPatch(typeof(TowerSelectionMenu), "UpdateHeroBooster")]
        public class FreeHeroUpgrade_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(TowerToSimulation tower)
            {
                tower.hero.hero.heroModel.costPerXpToLevel = (float)heroUpgradeCost/1000;
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