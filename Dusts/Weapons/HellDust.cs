using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Dusts.Weapons
{
    internal class HellDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.98f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            for (int i = -5; i < 6; i++)
            {
                Lighting.AddLight(
                    dust.position,
                    new Vector3(255f / (255f + i), 69f / (255f + i), 0f / (255f + i))
                );
            }

            return false;
        }
    }
}
