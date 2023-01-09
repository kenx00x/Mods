using HarmonyLib;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Blons_Corner_Map_Unlocker.Class1), "Blons/Corner Map Unlocker", "1.3.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Blons_Corner_Map_Unlocker
{
	public class Class1 : MelonMod
	{
		public override void OnApplicationStart()
		{
			MelonLogger.Msg("Blons/Corner Map Unlocker loaded!");
		}
		[HarmonyPatch(typeof(Game), "Awake")]
		public class Awake_Patch
		{
			[HarmonyPostfix]
			public static void Postfix()
			{
				for (int i = 0; i < GameData._instance.mapSet.Maps.items.Length; i++)
				{
					GameData._instance.mapSet.Maps.items[i].isBrowserOnly = false;
				}
			}
		}
	}
}