using MelonLoader;
using Assets.Scripts.Unity;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Models.Bloons;
using Harmony;
using Assets.Scripts.Unity.UI_New.InGame.BloonMenu;
[assembly: MelonInfo(typeof(BTD6_Golden_Bloon_In_Sandbox.Class1), "Golden Bloon In Sandbox", "1.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Golden_Bloon_In_Sandbox
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Golden Bloon In Sandbox loaded");
        }
        [HarmonyPatch(typeof(BloonMenu), "CreateBloonButtons")]
        public class MapLoader_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(List<BloonModel> sortedBloons)
            {
                foreach (var item in Game.instance.model.bloons)
                {
                    if (item.baseId == "Golden")
                    {
                        sortedBloons.Add(item);
                    }
                }
                return true;
            }
        }
    }
}