using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
namespace Valheim_Minecraft_Steve_Hairstyle
{
    [BepInPlugin("kenx00x.MinecraftSteveHairstyle", "Minecraft Steve Hairstyle", "1.2.0")]
    [BepInProcess("valheim.exe")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Patch)]
    public class MinecraftSteveHairstyle : BaseUnityPlugin
    {
        public void Awake()
        {
            AssetBundle embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("hairminecraftsteve", typeof(MinecraftSteveHairstyle).Assembly);
            GameObject steveHairstyle = embeddedResourceBundle.LoadAsset<GameObject>("Assets/customitems/steve/hairminecraftsteve.prefab");
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(MinecraftSteveHairstyle).Assembly.GetManifestResourceNames())}");

            CustomItem customItem = new CustomItem(steveHairstyle, false);
            ItemManager.Instance.AddItem(customItem);

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations =
                {
                    { "customization_hairminecraftsteve", "Minecraft Steve" }
                }
            });
        }
    }
}