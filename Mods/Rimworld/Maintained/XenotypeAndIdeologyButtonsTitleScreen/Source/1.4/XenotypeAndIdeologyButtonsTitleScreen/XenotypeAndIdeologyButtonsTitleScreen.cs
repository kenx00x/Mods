using HarmonyLib;
using Verse;
namespace XenotypeAndIdeologyButtonsTitleScreen
{
    [StaticConstructorOnStartup]
    public class XenotypeAndIdeologyButtonsTitleScreen : Mod
    {
        public XenotypeAndIdeologyButtonsTitleScreen(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("kenx00x.XenotypeAndIdeologyButtonsTitleScreen");
            harmony.PatchAll();
        }
    }
}