using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace BTD6_Among_Us_Tower
{
    public class BulletDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Bullet");
        }
    }
}