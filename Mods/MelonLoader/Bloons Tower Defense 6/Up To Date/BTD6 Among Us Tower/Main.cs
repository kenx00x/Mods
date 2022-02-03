using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using Main = BTD6_Among_Us_Tower.Main;

[assembly: MelonInfo(typeof(Main), "Among Us Tower", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Among_Us_Tower
{
    public class Main : BloonsTD6Mod
    {
        public static readonly ModSettingInt CrewMatePrice = new ModSettingInt(100);

        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Among Us Tower mod loaded");
        }
    }
}
