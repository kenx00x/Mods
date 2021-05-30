using Assets.Scripts.Models.Profile;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using MelonLoader;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using UnityEngine;
[assembly: MelonInfo(typeof(Trivia.Class1), "Trivia", "1.4.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace Trivia
{
    public class Class1 : MelonMod
    {
        public static string dir = $"{Directory.GetCurrentDirectory()}\\Mods\\Trivia";
        public static string config = $"{dir}\\config.txt";
        public static double multiplier = 25;
        public static double easyMultiplier = 1;
        public static double mediumMultiplier = 1;
        public static double hardMultiplier = 1;
        public static string difficulty = "";
        public static string question = "";
        public static string[] answers = new string[4];
        public static string correctAnswer = "";
        public static int staticRound;
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Trivia loaded");
            Directory.CreateDirectory($"{dir}");
            if (File.Exists(config))
            {
                MelonLogger.Msg("Reading config file");
                using (StreamReader sr = File.OpenText(config))
                {
                    int line = 0;
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        switch (line)
                        {
                            case 0:
                                multiplier = double.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                            case 1:
                                easyMultiplier = double.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                            case 2:
                                mediumMultiplier = double.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                            case 3:
                                hardMultiplier = double.Parse(s.Substring(s.IndexOf(char.Parse("=")) + 1));
                                break;
                        }
                        line++;
                    }
                }
                MelonLogger.Msg("Done reading");
            }
            else
            {
                MelonLogger.Msg("Creating config file");
                using (StreamWriter sw = File.CreateText(config))
                {
                    sw.WriteLine("Multiplier=25");
                    sw.WriteLine("EasyMultiplier=1");
                    sw.WriteLine("MediumMultiplier=1");
                    sw.WriteLine("HardMultiplier=1");
                }
                MelonLogger.Msg("Done Creating");
            }
        }
        public override void OnGUI()
        {
            if (question != "")
            {
                GUIStyle questionStyle = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter
                };
                questionStyle.normal.textColor = Color.white;
                Texture2D blackTexture = new Texture2D(1, 1);
                blackTexture.SetPixel(0, 0, Color.black);
                blackTexture.Apply();
                questionStyle.normal.background = blackTexture;
                Texture2D grayTexture = new Texture2D(1, 1);
                grayTexture.SetPixel(0, 0, Color.gray);
                grayTexture.Apply();
                GUIStyle buttonStyle = questionStyle;
                buttonStyle.hover.background = grayTexture;
                GUI.Label(new Rect(Screen.width / 2 - 400, 40, 800, 50f), question, questionStyle);
                if (GUI.Button(new Rect(Screen.width / 2 - 400, 90, 400, 30), answers[0], buttonStyle))
                {
                    CheckAnswer(answers[0]);
                }
                if (GUI.Button(new Rect(Screen.width / 2, 90, 400, 30), answers[1], buttonStyle))
                {
                    CheckAnswer(answers[1]);
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 400, 120, 400, 30), answers[2], buttonStyle))
                {
                    CheckAnswer(answers[2]);
                }
                if (GUI.Button(new Rect(Screen.width / 2, 120, 400, 30), answers[3], buttonStyle))
                {
                    CheckAnswer(answers[3]);
                }
            }
        }
        private void CheckAnswer(string answer)
        {
            if (correctAnswer == answer)
            {
                double addedMoney = 0;
                switch (difficulty)
                {
                    case "Easy":
                        addedMoney = staticRound * multiplier * easyMultiplier;
                        break;
                    case "Medium":
                        addedMoney = staticRound * multiplier * mediumMultiplier;
                        break;
                    case "Hard":
                        addedMoney = staticRound * multiplier * hardMultiplier;
                        break;
                }
                InGame.Bridge.simulation.cashManagers.entries[0].value.cash.Value += addedMoney;
                MelonLogger.Msg($"Correct, adding {addedMoney} cash");
            }
            else
            {
                MelonLogger.Msg($"Wrong, correct answer was: {correctAnswer}");
            }
            for (int i = 0; i < answers.Length - 1; i++)
            {
                answers[i] = "";
            }
            question = "";
        }
        [HarmonyPatch(typeof(Simulation), "OnRoundEnd")]
        public class Simulation_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(int round)
            {
                if (question == "")
                {
                    staticRound = round + 2;
                    System.Random rand = new System.Random();
                    string json = new WebClient().DownloadString("https://opentdb.com/api.php?amount=1");
                    JObject rss = JObject.Parse(json);
                    question = WebUtility.HtmlDecode((string)rss.SelectToken("results[0].question"));
                    correctAnswer = WebUtility.HtmlDecode((string)rss.SelectToken("results[0].correct_answer"));
                    answers[3] = correctAnswer;
                    JArray wrongAnswers = (JArray)rss.SelectToken("results[0].incorrect_answers");
                    for (int i = 0; i < wrongAnswers.Count; i++)
                    {
                        wrongAnswers[i] = WebUtility.HtmlDecode(wrongAnswers[i].ToString());
                        answers[i] = wrongAnswers[i].ToString();
                    }
                    for (int i = 0; i < answers.Length - 1; i++)
                    {
                        int random = rand.Next(i, answers.Length);
                        string temp = answers[i];
                        answers[i] = answers[random];
                        answers[random] = temp;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class MainMenu_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                question = "";
            }
        }
        [HarmonyPatch(typeof(MapInfo), "GetDifficulty")]
        public class MapInfo_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(string difficultyName)
            {
                difficulty = difficultyName;
            }
        }
    }
}