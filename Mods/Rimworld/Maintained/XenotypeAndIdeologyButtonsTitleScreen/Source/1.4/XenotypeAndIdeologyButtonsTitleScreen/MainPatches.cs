using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace XenotypeAndIdeologyButtonsTitleScreen
{
	public class MainPatches
	{
		[HarmonyPatch(typeof(MainMenuDrawer), "MainMenuOnGUI")]
		public class MainMenuDrawer_Patch
		{
			[HarmonyPrefix]
			public static void Prefix(ref Vector2 ___PaneSize)
			{
				___PaneSize = new Vector2(450f, 650f);
			}
		}

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
					if (XenotypeAndIdeologyButtonsTitleScreen.settings.menuOffset > optList.Count)
						XenotypeAndIdeologyButtonsTitleScreen.settings.menuOffset = optList.Count;
			        optList.Insert(XenotypeAndIdeologyButtonsTitleScreen.settings.menuOffset, new ListableOption("Ideology creator", delegate ()
			        {
				        Current.ProgramState = ProgramState.Entry;
				        Current.Game = new Game();
				        Current.Game.InitData = new GameInitData();
				        Current.Game.Scenario = ScenarioDefOf.Crashlanded.scenario;
				        Find.Scenario.PreConfigure();
				        Current.Game.storyteller = new Storyteller(StorytellerDefOf.Cassandra, DifficultyDefOf.Rough);
						var factions = new List<FactionDef>
						{
							FactionDefOf.PlayerColony
						};
						Current.Game.World = WorldGenerator.GenerateWorld(0f, "test", OverallRainfall.Normal, OverallTemperature.Normal, OverallPopulation.AlmostNone, factions, 0f);
						Find.GameInitData.startingTile = 0;
				        var page = Find.Scenario.GetFirstConfigPage();
				        page = page.next.next.next;
						page.prev = null;
						page.next = new ClosePage();
						Find.WindowStack.Add(page);
			        }, null));
					optList.Insert(XenotypeAndIdeologyButtonsTitleScreen.settings.menuOffset, new ListableOption("Xenotype creator", delegate ()
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