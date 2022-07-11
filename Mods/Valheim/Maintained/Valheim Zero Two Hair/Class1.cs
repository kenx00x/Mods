//credits to Sentimental-Dream for the hair https://www.deviantart.com/sentimental-dream
//credits to ichiibal for the horns https://www.deviantart.com/ichiibal
using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
namespace Valheim_Zero_Two_Hair
{
    [BepInPlugin("kenx00x.ZeroTwoHair", "Zero Two Hair", "1.2.0")]
    [BepInProcess("valheim.exe")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Patch)]
    public class ZeroTwoHair : BaseUnityPlugin
    {
        public void Awake()
        {
            AssetBundle embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("hairzerotwo", typeof(ZeroTwoHair).Assembly);
            GameObject zeroTwoHair = embeddedResourceBundle.LoadAsset<GameObject>("Assets/customitems/zerotwo/hairzerotwo.prefab");

            zeroTwoHair.transform.Find("attach_skin").Find("hair4").gameObject.AddComponent<ReassignBoneWeigthsToNewMesh>();

            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(ZeroTwoHair).Assembly.GetManifestResourceNames())}");

            CustomItem customItem = new CustomItem(zeroTwoHair, false);
            ItemManager.Instance.AddItem(customItem);

            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations =
                {
                    { "customization_hairzerotwo", "Zero Two Hair" }
                }
            });
        }
    }
}