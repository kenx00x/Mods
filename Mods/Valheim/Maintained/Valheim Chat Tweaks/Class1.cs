using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Utils;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Valheim_Chat_Tweaks
{
    [BepInPlugin("kenx00x.ChatTweaks", "Chat Tweaks", "1.2.0")]
    [BepInProcess("valheim.exe")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.NotEnforced, VersionStrictness.Patch)]
    public class ChatTweaks : BaseUnityPlugin
    {
        static public ConfigEntry<bool> enableAlwaysShout;
        static public ConfigEntry<float> hideDelay;
        static public ConfigEntry<KeyCode> chatKey;
        private readonly Harmony harmony = new Harmony("kenx00x.ChatTweaks");
        public void Awake()
        {
            enableAlwaysShout = Config.Bind("General","AlwaysShout",false,"Enable or disable to always shout");
            hideDelay = Config.Bind("General","ChatHideDelay",10f,"This value configures how fast the chat hides after sending/receiving a message.");
            chatKey = Config.Bind("General","ChatKey",KeyCode.Return,"This key is used to open the chat window.");
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
            public static void Prefix(ref float ___m_hideTimer, ref float ___m_hideDelay)
            {
                ___m_hideTimer = 0;
                if (hideDelay.Value >= 1f)
                {
                    ___m_hideDelay = hideDelay.Value;
                }
            }
        }
        static readonly MethodInfo m_InputText = AccessTools.Method(typeof(Chat), "InputText");
        static readonly FastInvokeHandler methodDelegate = MethodInvoker.GetHandler(m_InputText);
        [HarmonyPatch(typeof(Chat), "Update")]
        public class Chat3_Patch
        {
            public static bool Prefix(Chat __instance, ref float ___m_hideTimer, ref bool ___m_wasFocused)
            {
                ___m_hideTimer += Time.deltaTime;
                __instance.m_chatWindow.gameObject.SetActive(___m_hideTimer < __instance.m_hideDelay);
                if (!___m_wasFocused)
                {
                    if (Input.GetKeyDown(chatKey.Value) && Player.m_localPlayer != null && !global::Console.IsVisible() && !TextInput.IsVisible() && !Minimap.InTextInput() && !Menu.IsVisible())
                    {
                        ___m_hideTimer = 0f;
                        __instance.m_chatWindow.gameObject.SetActive(true);
                        __instance.m_input.gameObject.SetActive(true);
                        __instance.m_input.ActivateInputField();
                    }
                }
                else if (___m_wasFocused)
                {
                    ___m_hideTimer = 0f;
                    if (Input.GetKeyDown(chatKey.Value))
                    {
                        if (!string.IsNullOrEmpty(__instance.m_input.text))
                        {
                            methodDelegate(__instance);
                            __instance.m_input.text = "";
                        }
                        EventSystem.current.SetSelectedGameObject(null);
                        __instance.m_input.gameObject.SetActive(false);
                    }
                }
                ___m_wasFocused = __instance.m_input.isFocused;
                return false;
            }
        }
    }
}
