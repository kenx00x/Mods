using MelonLoader;
using Assets.Scripts.Unity;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Models.Bloons;
using HarmonyLib;
using Assets.Scripts.Unity.UI_New.InGame.BloonMenu;
[assembly: MelonInfo(typeof(BTD6_Lych_Boss_In_Sandbox.Class1), "Lych Boss In Sandbox", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Lych_Boss_In_Sandbox
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Lych Boss In Sandbox loaded");
        }
        [HarmonyPatch(typeof(BloonMenu), "CreateBloonButtons")]
        public class MapLoader_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(List<BloonModel> sortedBloons)
            {
                foreach (var item in Game.instance.model.bloons)
                {
                    if (item.baseId.Contains("Lych"))
                    {
                        sortedBloons.Add(item);
                    }
                }
                return true;
            }
        }
    }
}