using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Map;
using HarmonyLib;
using MelonLoader;
[assembly: MelonInfo(typeof(NoLeakDamage.Class1), "No leak damage", "2.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace NoLeakDamage
{
    public class Class1 : MelonMod
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