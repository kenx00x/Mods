using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using UnityEngine;
using UnityEngine.XR;

namespace SuchArtVRMod
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class VRPlugin : BaseUnityPlugin
    {
        // Metadata uniquely identifying your mod
        public const string PluginGUID = "com.kenx00x.suchart.vrmod";
        public const string PluginName = "SuchArt VR Mod";
        public const string PluginVersion = "1.0.0";

        public static VRPlugin Instance { get; private set; }
        private readonly Harmony _harmony = new Harmony(PluginGUID);

        private void Awake()
        {
            Instance = this;
            Logger.LogInfo("[SuchArtVR] Mod by kenx00x initializing...");

            try
            {
                // Inject all Harmony patches compiled into this assembly
                _harmony.PatchAll();
                Logger.LogInfo("[SuchArtVR] Harmony patches applied successfully.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"[SuchArtVR] Critical failure applying patches: {ex.Message}");
            }
        }
    }
}