using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Utils;
namespace Valheim_Chat_Tweaks
{
    [BepInPlugin("kenx00x.ChatTweaks", "Chat Tweaks", "1.0.0")]
    [BepInProcess("valheim.exe")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Patch)]
    public class ChatTweaks : BaseUnityPlugin
    {
        static public ConfigEntry<bool> enableAlwaysShout;
        private readonly Harmony harmony = new Harmony("kenx00x.ChatTweaks");
        public void Awake()
        {
            enableAlwaysShout = Config.Bind("General","AlwaysShout",false,"Enable or disable to always shout");
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(Chat), "SendText")]
        public class Chat2_Patch
        {
            public static bool Prefix(ref Talker.Type type)
            {
                if (enableAlwaysShout.Value)
                {
                    type = Talker.Type.Shout;
                }
                return true;
            }
        }
        [HarmonyPatch(typeof(Chat), "OnNewChatMessage")]
        public class Chat_Patch
        {
            public static void Prefix(ref float ___m_hideTimer)
            {
                ___m_hideTimer = 0;
            }
        }
    }
}