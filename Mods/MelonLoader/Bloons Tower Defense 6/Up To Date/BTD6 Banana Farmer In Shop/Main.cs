using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using Main = Banana_Farmer_In_Shop.Main;

[assembly: MelonInfo(typeof(Main), "Banana Farmer In Shop", "3.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace Banana_Farmer_In_Shop
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt Price = new ModSettingInt(550);

        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Banana Farmer In Shop mod loaded");
        }
    }
}