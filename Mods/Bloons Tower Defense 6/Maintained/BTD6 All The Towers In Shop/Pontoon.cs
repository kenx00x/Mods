using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;

namespace BTD6_All_The_Towers_In_Shop
{
    public class Pontoon : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("Pontoon").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("Pontoon").icon;
		public override TowerSet TowerSet => TowerSet.Support;
		public override string BaseTower => TowerType.Pontoon;
        public override int Cost => Main.PontoonPrice;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Pontoon";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}