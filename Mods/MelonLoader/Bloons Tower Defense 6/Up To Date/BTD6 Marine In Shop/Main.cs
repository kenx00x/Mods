using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using Main = BTD6_Marine_In_Shop.Main;

[assembly: MelonInfo(typeof(Main), "Marine In Shop", "3.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Marine_In_Shop
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt Price = new ModSettingInt(135000);

        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Marine In Shop mod loaded");
        }
    }
}