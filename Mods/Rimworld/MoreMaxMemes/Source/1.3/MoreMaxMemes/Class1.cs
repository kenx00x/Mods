using HarmonyLib;
using Verse;
using RimWorld;
using System.Reflection;

namespace MoreMaxMemes
{
    [StaticConstructorOnStartup]
    public class MoreMaxMemes : Mod
    {
        public MoreMaxMemes(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("kenx00x.MoreMaxMemes");
            harmony.PatchAll();
        }
    }
    [HarmonyPatch(typeof(IdeoFoundation), "InitPrecepts")]
    public class Chat_Patch
    {
        public static void Prefix(ref IntRange ___MemeCountRangeAbsolute)
        {
            ___MemeCountRangeAbsolute = new IntRange(0, 100);
        }
    }
}
