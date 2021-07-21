using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
namespace MoreMaxMemes
{
    [StaticConstructorOnStartup]
    public class MoreMaxMemes : Mod
    {
        MoreMaxMemesSettings settings;
        public MoreMaxMemes(ModContentPack content) : base(content)
        {
            settings = GetSettings<MoreMaxMemesSettings>();
            var harmony = new Harmony("kenx00x.MoreMaxMemes");
            harmony.PatchAll();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Label("Minimum meme value");
            string text = settings.minimumMeme.ToString();
            listing_Standard.TextFieldNumeric(ref settings.minimumMeme, ref text);
            listing_Standard.Label("Maximum meme value");
            string text2 = settings.maximumMeme.ToString();
            listing_Standard.TextFieldNumeric(ref settings.maximumMeme, ref text2);
            listing_Standard.End();
        }
        public override string SettingsCategory()
        {
            return "More Max Memes";
        }
    }
    [HarmonyPatch(typeof(IdeoFoundation), "InitPrecepts")]
    public class InitPrecepts_Patch
    {
        public static void Prefix(ref IntRange ___MemeCountRangeAbsolute)
        {
            MoreMaxMemesSettings settings = LoadedModManager.GetMod<MoreMaxMemes>().GetSettings<MoreMaxMemesSettings>();
            ___MemeCountRangeAbsolute = new IntRange(settings.minimumMeme, settings.maximumMeme);
        }
    }
    public class MoreMaxMemesSettings : ModSettings
    {
        public int minimumMeme = 0;
        public int maximumMeme = 100;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref minimumMeme, "MinimumMeme", 0);
            Scribe_Values.Look(ref maximumMeme, "MaximumMeme", 100);
        }
    }
}