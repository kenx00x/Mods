using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using Main = BTD6_Mini_Sun_Avatar_In_Shop.Main;

[assembly: MelonInfo(typeof(Main), "Mini Sun Avatar In Shop", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Mini_Sun_Avatar_In_Shop
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt Price = new ModSettingInt(150000);

        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Mini Sun Avatar In Shop mod loaded");
        }
    }
}