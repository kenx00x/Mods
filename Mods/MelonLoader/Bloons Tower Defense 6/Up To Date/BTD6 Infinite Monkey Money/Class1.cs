using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using MelonLoader;
using System.IO;
[assembly: MelonInfo(typeof(BTD6_Infinite_Monkey_Money.Class1), "Infinite Monkey Money", "1.1.1", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Infinite_Monkey_Money
{
    public class Class1 : MelonMod
    {
        public static string dir = $"{Directory.GetCurrentDirectory()}\\Mods\\InfiniteMonkeyMoney";
        public static string config = $"{dir}\\config.txt";
        public static int amount = 999999999;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Infinite Monkey Money loaded!");
            Directory.CreateDirectory($"{dir}");
            if (File.Exists(config))
            {
                MelonLogger.Msg("Reading config file");
                using (StreamReader sr = File.OpenText(config))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        amount = int.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                    }
                }
                MelonLogger.Msg("Done reading");
            }
            else
            {
                MelonLogger.Msg("Creating config file");
                using (StreamWriter sw = File.CreateText(config))
                {
                    sw.WriteLine("Amount=999999999");
                }
                MelonLogger.Msg("Done Creating");
            }
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                Game.instance.playerService.Player.Data.monkeyMoney.Value = amount;
            }
        }
    }
}