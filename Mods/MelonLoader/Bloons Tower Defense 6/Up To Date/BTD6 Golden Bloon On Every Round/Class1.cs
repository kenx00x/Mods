using MelonLoader;
using Assets.Scripts.Unity;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
using Harmony;
using Assets.Scripts.Simulation;
[assembly: MelonInfo(typeof(BTD6_Golden_Bloon_On_Every_Round.Class1), "Golden Bloon On Every Round", "1.1.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_Golden_Bloon_On_Every_Round
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Golden Bloon On Every Round loaded");
        }
        [HarmonyPatch(typeof(Simulation), "InitialiseMap")]
        public class MapLoader_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                List<BloonModel> goldenBloons = new List<BloonModel>();
                foreach (var item in Game.instance.model.bloons)
                {
                    if (item.baseId == "Golden")
                    {
                        goldenBloons.Add(item);
                    }
                }
                Random rand = new Random();
                Il2CppReferenceArray<RoundSetModel> roundSets = InGame.instance.bridge.Model.roundSets;
                for (int i = 0; i < roundSets.Length; i++)
                {
                    Il2CppReferenceArray<RoundModel> rounds = roundSets[i].rounds;
                    for (int j = 0; j < rounds.Length; j++)
                    {
                        int randombloon = rand.Next(0, goldenBloons.Count);
                        BloonEmissionModel goldenBloon = new BloonEmissionModel(goldenBloons[randombloon].id, 0, goldenBloons[randombloon].id);
                        Il2CppReferenceArray<BloonEmissionModel> temp = rounds[j].emissions;
                        List<BloonEmissionModel> temp2 = new List<BloonEmissionModel>();
                        foreach (var item in temp)
                        {
                            temp2.Add(item);
                        }
                        temp2.Add(goldenBloon);
                        rounds[j].emissions_ = (Il2CppReferenceArray<BloonEmissionModel>)temp2.ToArray();
                    }
                }
            }
        }
    }
}