using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
namespace BTD6_Cave_Monkey_In_Shop
{
    public class CaveMonkey : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("CaveMonkey").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("CaveMonkey").icon;
        public override string TowerSet => PRIMARY;
        public override string BaseTower => TowerType.CaveMonkey;
        public override int Cost => Main.Price;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Cave Monkey";
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}