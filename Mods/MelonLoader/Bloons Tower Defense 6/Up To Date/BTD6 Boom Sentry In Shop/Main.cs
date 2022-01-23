using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_Boom_Sentry_In_Shop.Main), "Boom Sentry In Shop", "3.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Boom_Sentry_In_Shop
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt Price = new ModSettingInt(500);
        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Boom Sentry In Shop mod loaded");
        }
    }
}