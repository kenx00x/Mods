using HarmonyLib;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Main;

[assembly: MelonInfo(typeof(BTD6_Infinite_Tower_XP.Class1), "Infinite Tower XP", "1.3.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Infinite_Tower_XP
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingInt xp = new ModSettingInt(999999999);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Infinite Tower XP loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class MainMenu_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                for (int i = 0; i < Game.instance.model.towers.Count; i++)
                {
                    Game.instance.playerService.Player.AddTowerXP(Game.instance.model.towers[i].name,100);
                }
                foreach (var item in Game.instance.playerService.Player.Data.towerXp)
                {
                    Game.instance.playerService.Player.Data.towerXp[item.key].Value = xp;
                }
            }
        }
    }
}