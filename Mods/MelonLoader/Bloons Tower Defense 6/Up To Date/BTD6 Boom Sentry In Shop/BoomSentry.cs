using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
namespace BTD6_Boom_Sentry_In_Shop
{
    public class BoomSentry : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("SentryBoom").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("SentryBoom").icon;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.SentryBoom;
        public override int Cost => Main.Price;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Boom Sentry";
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}