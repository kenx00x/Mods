using BepInEx;
using HarmonyLib;
using SuchArt_VR.Helpers;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR;
using Valve.VR;

namespace SuchArtVRMod
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class VRPlugin : BaseUnityPlugin
    {
        // Metadata uniquely identifying your mod
        public const string PLUGIN_GUID = "com.kenx00x.suchart.vrmod";
        public const string PLUGIN_NAME = "SuchArt VR Mod";
        public const string PLUGIN_VERSION = "1.0.0";

        public static string gameExePath = Process.GetCurrentProcess().MainModule.FileName;
        public static string gamePath = Path.GetDirectoryName(gameExePath);
        public static string HMDModel = "";

        public static UnityEngine.XR.Management.XRManagerSettings managerSettings = null;

        public static List<UnityEngine.XR.XRDisplaySubsystemDescriptor> displaysDescs = new List<UnityEngine.XR.XRDisplaySubsystemDescriptor>();
        public static List<UnityEngine.XR.XRDisplaySubsystem> displays = new List<UnityEngine.XR.XRDisplaySubsystem>();
        public static UnityEngine.XR.XRDisplaySubsystem MyDisplay = null;

        public static GameObject SecondEye = null;
        public static Camera SecondCam = null;

        public class MyStaticMB : MonoBehaviour
        {
        }

        //Variable reference for the class
        public static MyStaticMB myStaticMB;

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

           // new AssetLoader();

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            //If the instance not exit the first time we call the static class
            if (myStaticMB == null)
            {
                //Create an empty object called MyStatic
                GameObject gameObject = new GameObject("MyStatic");


                //Add this script to the object
                myStaticMB = gameObject.AddComponent<MyStaticMB>();
            }

            myStaticMB.StartCoroutine(InitVRLoader());
        }

        public static System.Collections.IEnumerator InitVRLoader()
        {

            SteamVR_Actions.PreInitialize();

            var generalSettings = ScriptableObject.CreateInstance<XRGeneralSettings>();
            managerSettings = ScriptableObject.CreateInstance<XRManagerSettings>();
            var xrLoader = ScriptableObject.CreateInstance<OpenVRLoader>();


            var settings = OpenVRSettings.GetSettings();
            settings.StereoRenderingMode = OpenVRSettings.StereoRenderingModes.MultiPass;


            generalSettings.Manager = managerSettings;

            managerSettings.loaders.Clear();
            managerSettings.loaders.Add(xrLoader);

            managerSettings.InitializeLoaderSync(); ;


            var initMethod = AccessTools.Method(typeof(XRGeneralSettings), "AttemptInitializeXRSDKOnLoad");
            if (initMethod != null)
                initMethod.Invoke(null, null);

            var startMethod = AccessTools.Method(typeof(XRGeneralSettings), "AttemptStartXRSDKOnBeforeSplashScreen");
            if (startMethod != null)
                startMethod.Invoke(null, null);

            SteamVR.Initialize(true);

            SubsystemManager.GetInstances(displays);
            MyDisplay = displays[0];
            MyDisplay.Start();

            Logs.WriteInfo("SteamVR hmd modelnumber: " + SteamVR.instance.hmd_ModelNumber);
            HMDModel = SteamVR.instance.hmd_ModelNumber;

            //new VRInputManager();

            Logs.WriteInfo("Reached end of InitVRLoader");

            yield return null;

        }
    }
}