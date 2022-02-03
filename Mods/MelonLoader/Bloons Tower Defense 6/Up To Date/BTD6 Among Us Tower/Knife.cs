using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6_Among_Us_Tower
{
    public class Knife : ModUpgrade<Crewmate>
    {
        public override string Name => "Knife";
        public override string DisplayName => "Knife";
        public override string Description => "The crewmate decided to betray us and become an imposter.";
        public override int Cost => 69;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override string Icon => "Knife_Icon";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range = 20f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
            var attackModel = towerModel.GetAttackModel();
            Crewmate.Weapon.projectile.ApplyDisplay<KnifeDisplay>();
            Crewmate.Weapon.projectile.GetBehavior<TravelStraitModel>().Speed = 10f;
            Crewmate.Weapon.projectile.GetBehavior<TravelStraitModel>().lifespan = 1;
            Crewmate.Weapon.projectile.CanHitCamo();
            attackModel.AddWeapon(Crewmate.Weapon);
            attackModel.range = 20f;
        }
    }
}