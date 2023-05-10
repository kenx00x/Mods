using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using RimWorld.Planet;
using Verse;

namespace XenotypeAndIdeologyButtonsTitleScreen
{
	public class MainPatches
	{
		[HarmonyPatch(typeof(OptionListingUtility), "DrawOptionListing")]
	    public class OptionListingUtility_Patch
		{
			private static bool correctList;

			[HarmonyPrefix]
	        public static void Prefix(ref List<ListableOption> optList)
	        {
		        if (Current.ProgramState != ProgramState.Entry) return;
		        foreach (var listableOption in optList)
		        {
			        if (listableOption.label == "Credits".Translate())
			        {
				        correctList = true;
			        }
		        }

		        if (correctList)
		        {
			        optList.Insert(0, new ListableOption("Ideology creator", delegate ()
			        {
				        Current.ProgramState = ProgramState.Entry;
				        Current.Game = new Game();
				        Current.Game.InitData = new GameInitData();
				        Current.Game.Scenario = ScenarioDefOf.Crashlanded.scenario;
				        Find.Scenario.PreConfigure();
				        Current.Game.storyteller = new Storyteller(StorytellerDefOf.Cassandra, DifficultyDefOf.Rough);
				        Current.Game.World = WorldGenerator.GenerateWorld(0.03f, GenText.RandomSeedString(), OverallRainfall.Normal, OverallTemperature.Normal, OverallPopulation.Normal, null, 0f);
				        Find.GameInitData.ChooseRandomStartingTile();
				        Find.GameInitData.mapSize = 150;
				        var page = Find.Scenario.GetFirstConfigPage();
				        page = page.next.next.next;
						page.prev = null;
						page.next = new ClosePage();
						Find.WindowStack.Add(page);
			        }, null));
					optList.Insert(0, new ListableOption("Xenotype creator", delegate ()
					{
						var menu = new Dialog_CreateXenotype2(0, delegate()
						{
							CharacterCardUtility.cachedCustomXenotypes = null;
						});
						Find.WindowStack.Add(menu);
					}, null));
				}
				correctList = false;
			}
	    }
	}
}