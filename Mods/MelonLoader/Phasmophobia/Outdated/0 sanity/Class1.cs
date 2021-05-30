using MelonLoader;
namespace _0_sanity
{
    public class Class1 : MelonMod
    {
        public override void OnUpdate()
        {
            //unobfuscated
            //GameController.instance.myPlayer.player.insanity = 100;
            //obfuscared but due to a bug currently unusable
            ////GameController.field_Public_Static_GameController_0.field_Public_ObjectPublicPlStPlUnique_0.field_Public_Player_0.field_Public_Single_0 = 100;
            Player LocalPlayer = Helpers.GetLocalPlayer();
            LocalPlayer.field_Public_Single_0 = 100;
        }
        public override void OnApplicationStart()
        {
            MelonLogger.Log("0 sanity mod loaded!");
        }
    }
}