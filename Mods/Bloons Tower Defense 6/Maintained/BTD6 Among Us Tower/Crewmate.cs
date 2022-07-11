using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Weapons;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6_Among_Us_Tower
{
    public class Crewmate : ModTower
    {
        public static WeaponModel Weapon;
        public override bool Use2DModel => true;
        public override string Portrait => "Crewmate Icon Portrait";
        public override string Icon => "Crewmate Icon Portrait";
        public override string TowerSet => PRIMARY;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => Main.CrewMatePrice;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 2;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Crewmate";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 100f;
            var attackModel = towerModel.GetAttackModel();
            foreach (var weapon in attackModel.weapons)
            {
                Weapon = weapon;
                attackModel.RemoveWeapon(weapon);
            }
            attackModel.range = 100f;
        }
    }
}