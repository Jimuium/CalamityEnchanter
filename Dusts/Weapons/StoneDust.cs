using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Dusts.Weapons
{
    internal class StoneDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            //dust.rotation += dust.velocity.X * 0.15f;
            dust.rotation = 0;
            dust.scale *= 0.98f;
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }

            Lighting.AddLight(dust.position, new Vector3(120f / 255f, 120f / 255f, 120f / 255f));

            return false;
        }
    }
}
