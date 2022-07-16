using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;

namespace BTD6_All_The_Towers_In_Shop
{
    public class TransFormedBaseMonkey : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("Alchemist-050").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("Alchemist-050").portrait;
        public override string TowerSet => MAGIC;
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