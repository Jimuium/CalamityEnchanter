using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Dusts.Accessories
{
    internal class BlessingDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
            dust.frame = new Rectangle(0, 0, 14, 18);
        }

        private int timeLeft = 60;

        public override bool Update(Dust dust)
        {
            if (timeLeft < 0)
            {
                dust.active = false;
                timeLeft = 60;
            }
            timeLeft--;
            dust.position += dust.velocity;

            Lighting.AddLight(dust.position, new Vector3(243f / 255f, 223f / 255f, 137f / 255f));
            if (dust.velocity == new Vector2(0, 0.05f))
                dust.active = false;

            return false;
        }
    }
}
