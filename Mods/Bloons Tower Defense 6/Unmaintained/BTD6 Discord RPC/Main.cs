using Assets.Scripts.Models;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.UI_New.InGame.Stats;
using Assets.Scripts.Unity.UI_New.Main;
using Discord;
using Harmony;
using MelonLoader;
using System.Text.RegularExpressions;
using UnityEngine;
[assembly: MelonInfo(typeof(BTD6DiscordRPC.Main), "BTD6 Discord RPC", "2.2.1", "kenx00x, rambini")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6DiscordRPC
{
    public class Main : MelonMod
    {
        public static string cashMoneyText = "";
        public static string cashMoneyIcon = "";
        public static string shield = "";
        public static string health = "";
        public static string money = "";
        public static string mode = "";
        public static string difficulty = "";
        public static string round = "";
        public static string currentMap = "";
        public static Discord.Discord discord;
        public override void OnApplicationStart()
        {
            MelonLogger.Log("BTD6 Discord RPC loaded!");
            discord = new Discord.Discord(778339584408027176, (ulong)CreateFlags.Default);
        }
        public override void OnUpdate()
        {
            HealthDisplay[] CurrentHealthUI = Object.FindObjectsOfType<HealthDisplay>();
            foreach (var item in CurrentHealthUI)
            {
                health = $"Health: {item.text.m_text}";
            }
            RoundDisplay[] CurrentRoundUI = Object.FindObjectsOfType<RoundDisplay>();
            foreach (var item in CurrentRoundUI)
            {
                round = $"Round: {item.text.m_text}";
            }
            CashDisplay[] CurrentMoneyUI = Object.FindObjectsOfType<CashDisplay>();
            foreach (var item in CurrentMoneyUI)
            {
                money = $"Money: {item.text.m_text}";
            }
            bool hasShield = false;
            RectTransform[] hideMe = Object.FindObjectsOfType<RectTransform>();
            foreach (var item in hideMe)
            {
                if (item.name == "HideMe")
                {
                    hasShield = true;
                }
            }
            if (hasShield)
            {
                ShieldDisplay[] CurrentShieldUI = Object.FindObjectsOfType<ShieldDisplay>();
                foreach (var item in CurrentShieldUI)
                {
                    shield = $"Shield: {item.text.m_text}";
                }
            }
            else
            {
                shield = "";
            }
            if (health != "")
            {
                cashMoneyIcon = "cashmoney";
                cashMoneyText = $"{health} {shield} {money}";
            }
            UpdateActivityFunction();
            discord.RunCallbacks();
        }
        [HarmonyPatch(typeof(MapLoader), "Load")]
        public class MapLoader_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(string map)
            {
                currentMap = "";
                string[] mapSplit = Regex.Split(map, @"(?<!^)(?=[A-Z])");
                foreach (var item in mapSplit)
                {
                    currentMap += $"{item} ";
                }
                if (currentMap == "Tutorial ")
                {
                    currentMap = "Monkey Meadow";
                }
            }
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class MainMenu_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                shield = "";
                cashMoneyText = "";
                health = "";
                money = "";
                difficulty = "";
                mode = "";
                currentMap = "Main menu";
                round = "";
                cashMoneyIcon = "";
                UpdateActivityFunction();
            }
        }
        [HarmonyPatch(typeof(Simulation), "InitialiseDifficulty")]
        public class UnityToSimulation_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(string newDifficulty)
            {
                difficulty = $"{newDifficulty} Difficulty - ";
            }
        }
        [HarmonyPatch(typeof(Simulation), "Initialise")]
        public class Simulation_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(GameModel model)
            {
                mode = "";
                string[] gameModeSplit = Regex.Split(model.gameMode, @"(?<!^)(?=[A-Z])");
                foreach (var item in gameModeSplit)
                {
                    mode += $"{item} ";
                }
                if (mode == "Clicks ")
                {
                    mode = "Chimps";
                }
            }
        }
        private static void UpdateActivityFunction()
        {
            var activityManager = discord.GetActivityManager();
            var activity = new Activity
            {
                Details = currentMap,
                State = round,
                Assets =
                {
                    LargeImage = "mainimage",
                    LargeText = $"{difficulty}{mode}",
                    SmallImage = cashMoneyIcon,
                    SmallText = cashMoneyText
                }
            };
            activityManager.UpdateActivity(activity, (res) => { });
        }
    }
}