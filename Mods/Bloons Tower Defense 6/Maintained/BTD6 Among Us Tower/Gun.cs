using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BTD6_Among_Us_Tower
{
    public class Gun : ModUpgrade<Crewmate>
    {
        public override string Name => "Gun";
        public override string DisplayName => "Gun";
        public override string Description => "Don't bring a knife to a gun fight, bring this gun instead!";
        public override int Cost => Main.GunPrice;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override string Icon => "Gun_Icon";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range = 75f;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.ApplyDisplay<BulletDisplay>();
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 100f;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan = 1;
            attackModel.range = 75f;
        }
    }
}