using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;
[assembly: MelonInfo(typeof(freeTowers.Class1), "free towers and upgrades", "1.3.0", "kenx00x")]
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