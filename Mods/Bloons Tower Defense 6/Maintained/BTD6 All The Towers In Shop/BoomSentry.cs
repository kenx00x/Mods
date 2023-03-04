using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Collections.Generic;

namespace BTD6_All_The_Towers_In_Shop
{
    public class BoomSentry : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("SentryBoom").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("SentryBoom").portrait;
		public override TowerSet TowerSet => TowerSet.Support;
		public override string BaseTower => TowerType.SentryBoom;
        public override int Cost => Main.BoomSentryPrice;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Boom Sentry";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.radius = 6;
            towerModel.radiusSquared = 36;
            towerModel.footprint.doesntBlockTowerPlacement = false;
            var temp = new List<Model>();
            foreach (var behavior in towerModel.behaviors)
                if (behavior.name != "TowerExpireModel_") temp.Add(behavior);
            towerModel.behaviors = (Il2CppReferenceArray<Model>)temp.ToArray();
        }
    }
}