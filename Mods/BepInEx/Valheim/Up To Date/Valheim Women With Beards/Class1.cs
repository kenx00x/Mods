using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace Valheim_Women_With_Beards
{
    [BepInPlugin("kenx00x.WomenWithBeards", "Women With Beards", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class WomenWithBeards : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("kenx00x.WomenWithBeards");
        public void Awake()
        {
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(PlayerCustomizaton), "ResetBeard")]
        public class ResetBeard_Patch
        {
            public static bool Prefix()
            {
                return false;
            }
        }
        static readonly MethodInfo m_SetBeard = AccessTools.Method(typeof(PlayerCustomizaton), "SetBeard");
        static readonly FastInvokeHandler methodDelegate = MethodInvoker.GetHandler(m_SetBeard);
        static readonly MethodInfo m_GetBeardIndex = AccessTools.Method(typeof(PlayerCustomizaton), "GetBeardIndex");
        static readonly FastInvokeHandler methodDelegate2 = MethodInvoker.GetHandler(m_GetBeardIndex);
        [HarmonyPatch(typeof(PlayerCustomizaton), "OnBeardLeft")]
        public class LeftBeard_Patch
        {
            public static bool Prefix(PlayerCustomizaton __instance)
            {
                methodDelegate((__instance), (int)methodDelegate2(__instance) - 1);
                return false;
            }
        }
        [HarmonyPatch(typeof(PlayerCustomizaton), "OnBeardRight")]
        public class RightBeard_Patch
        {
            public static bool Prefix(PlayerCustomizaton __instance)
            {
                methodDelegate((__instance), (int)methodDelegate2(__instance) + 1);
                return false;
            }
        }
    }
}