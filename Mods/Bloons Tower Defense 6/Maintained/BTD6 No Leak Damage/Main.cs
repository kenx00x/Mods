using HarmonyLib;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Map;
using MelonLoader;
[assembly: MelonInfo(typeof(NoLeakDamage.Main), "No leak damage", "3.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace NoLeakDamage
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("No leak damage mod loaded");
        }
        [HarmonyPatch(typeof(MapLoader), "Load")]
        public class MapLoader_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (BloonModel bloon in Game.instance.model.bloons)
                {
                    bloon.leakDamage = 0;
                }
            }
        }
    }
}