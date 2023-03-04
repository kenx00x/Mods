using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;

namespace BTD6_All_The_Towers_In_Shop
{
    public class TransFormedBaseMonkey : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("Alchemist-050").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("Alchemist-050").portrait;
		public override TowerSet TowerSet => TowerSet.Magic;
		public override string BaseTower => "TransformedBaseMonkey";
        public override int Cost => Main.TransFormedBaseMonkeyPrice;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "TransFormed Base Monkey";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}