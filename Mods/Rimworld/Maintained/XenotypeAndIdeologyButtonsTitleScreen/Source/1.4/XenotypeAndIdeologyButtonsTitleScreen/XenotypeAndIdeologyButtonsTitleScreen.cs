using HarmonyLib;
using UnityEngine;
using Verse;
namespace XenotypeAndIdeologyButtonsTitleScreen
{
    [StaticConstructorOnStartup]
    public class XenotypeAndIdeologyButtonsTitleScreen : Mod
    {
        public static CustomSettings settings;
        public XenotypeAndIdeologyButtonsTitleScreen(ModContentPack content) : base(content)
        {
	        settings = GetSettings<CustomSettings>();
			var harmony = new Harmony("kenx00x.XenotypeAndIdeologyButtonsTitleScreen");
            harmony.PatchAll();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
	        Listing_Standard listing_Standard = new Listing_Standard();
	        listing_Standard.Begin(inRect);
	        listing_Standard.Label("The offset of the buttons in the main menu.");
	        string text = settings.menuOffset.ToString();
	        listing_Standard.TextFieldNumeric(ref settings.menuOffset, ref text);
	        listing_Standard.End();
        }
        public override string SettingsCategory()
        {
	        return "More Max Memes";
        }
	}
    public class CustomSettings : ModSettings
    {
	    public int menuOffset = 0;
	    public override void ExposeData()
	    {
		    Scribe_Values.Look(ref menuOffset, "MenuOffset", 0);
	    }
    }
}