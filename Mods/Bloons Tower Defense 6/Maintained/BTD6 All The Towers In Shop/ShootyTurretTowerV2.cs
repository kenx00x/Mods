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
    public class ShootyTurretTowerV2 : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("ShootyTurretTowerV2").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("ShootyTurretTowerV2").portrait;
		public override TowerSet TowerSet => TowerSet.Primary;
		public override string BaseTower => "ShootyTurretTowerV2";
        public override int Cost => Main.ShootyTurretTowerV2Price;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Shooty Turret Tower V2";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.geraldoItemName = null;
            var temp = new List<Model>();
            foreach (var behavior in towerModel.behaviors)
                if (behavior.name != "TowerExpireModel_") temp.Add(behavior);
            towerModel.behaviors = (Il2CppReferenceArray<Model>)temp.ToArray();
        }
    }
}