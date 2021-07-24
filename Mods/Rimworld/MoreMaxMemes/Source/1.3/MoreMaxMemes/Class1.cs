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
            listing_Standard.Label("NPC initial minimum meme value");
            string text3 = settings.NPCInitialMinimumMeme.ToString();
            listing_Standard.TextFieldNumeric(ref settings.NPCInitialMinimumMeme, ref text3);
            listing_Standard.Label("NPC initial maximum meme value");
            string text4 = settings.NPCInitialMaximumMeme.ToString();
            listing_Standard.TextFieldNumeric(ref settings.NPCInitialMaximumMeme, ref text4);
            listing_Standard.Label("Maximum venerated animals value");
            string text5 = settings.maximumVeneratedAnimals.ToString();
            listing_Standard.TextFieldNumeric(ref settings.maximumVeneratedAnimals, ref text5);
            listing_Standard.End();
        }
        public override string SettingsCategory()
        {
            return "More Max Memes";
        }
        public static void MyMethod(ref IntRange ___MemeCountRangeAbsolute,ref IntRange ___MemeCountRangeNPCInitial)
        {
            MoreMaxMemesSettings settings = LoadedModManager.GetMod<MoreMaxMemes>().GetSettings<MoreMaxMemesSettings>();
            ___MemeCountRangeAbsolute = new IntRange(settings.minimumMeme, settings.maximumMeme);
            ___MemeCountRangeNPCInitial = new IntRange(settings.NPCInitialMinimumMeme, settings.NPCInitialMaximumMeme);
            PreceptDefOf.AnimalVenerated.maxCount = settings.maximumVeneratedAnimals;
        }
    }
    [HarmonyPatch(typeof(IdeoFoundation), "InitPrecepts")]
    public class InitPrecepts_Patch
    {
        public static void Prefix(ref IntRange ___MemeCountRangeAbsolute, ref IntRange ___MemeCountRangeNPCInitial)
        {
            MoreMaxMemes.MyMethod(ref ___MemeCountRangeAbsolute,ref ___MemeCountRangeNPCInitial);
        }
    }
    [HarmonyPatch(typeof(IdeoFoundation), "ExposeData")]
    public class ExposeData_Patch
    {
        public static void Prefix(ref IntRange ___MemeCountRangeAbsolute, ref IntRange ___MemeCountRangeNPCInitial)
        {
            MoreMaxMemes.MyMethod(ref ___MemeCountRangeAbsolute, ref ___MemeCountRangeNPCInitial);
        }
    }
    public class MoreMaxMemesSettings : ModSettings
    {
        public int minimumMeme = 0;
        public int maximumMeme = 100;
        public int NPCInitialMinimumMeme = 1;
        public int NPCInitialMaximumMeme = 3;
        public int maximumVeneratedAnimals = 18;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref minimumMeme, "MinimumMeme", 0);
            Scribe_Values.Look(ref maximumMeme, "MaximumMeme", 100);
            Scribe_Values.Look(ref NPCInitialMinimumMeme, "NPCInitialMinimumMeme", 1);
            Scribe_Values.Look(ref NPCInitialMaximumMeme, "NPCInitialMaximumMeme", 3);
            Scribe_Values.Look(ref maximumVeneratedAnimals, "MaximumVeneratedAnimals", 18);
        }
    }
}