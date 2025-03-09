using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Dusts.Accessories
{
    internal class HolyShieldDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.velocity *= 0.95f;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.995f;
            if (dust.scale < 0.4f)
            {
                dust.active = false;
            }
            Lighting.AddLight(dust.position, new Vector3(214f / 255f, 1, 0));

            return false;
        }
    }
}
