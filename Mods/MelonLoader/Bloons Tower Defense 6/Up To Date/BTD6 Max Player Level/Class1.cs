using Assets.Scripts.Models.Profile;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Max_Player_level.Class1), "Max Player Level", "1.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Max_Player_level
{
    public class Class1 : BloonsTD6Mod
    {
        public static ModSettingDouble xp = new ModSettingDouble(999999999);
        public static ModSettingDouble VeteranXp = new ModSettingDouble(999999999);
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Max Player Level loaded!");
        }
        [HarmonyPatch(typeof(ProfileModel), "Validate")]
        public class ProfileModel_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ProfileModel __instance)
            {
                __instance.xp.Value = xp;
                __instance.veteranXp.Value = VeteranXp;
                __instance.veteranRank.Value = ((VeteranXp - (VeteranXp % 20000000)) / 20000000) + 1;
            }
        }
    }
}