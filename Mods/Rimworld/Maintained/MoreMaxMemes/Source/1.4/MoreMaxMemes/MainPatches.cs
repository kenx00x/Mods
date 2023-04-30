using HarmonyLib;
using RimWorld;
using Verse;
namespace MoreMaxMemes
{
	public class MainPatches
	{
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
	}
}