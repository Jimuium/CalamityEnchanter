using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityEnchanter.Dusts.Weapons
{
    internal class HexDust : ModDust
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
            dust.scale *= 0.95f;
            if (dust.scale < 0.7f)
            {
                Dust.NewDust(
                    dust.position,
                    1,
                    1,
                    ModContent.DustType<DarkHexDust>(),
                    dust.velocity.X * -0.5f,
                    dust.velocity.Y * -0.5f
                );
                dust.active = false;
            }

            Lighting.AddLight(dust.position, new Vector3(141f, 76f, 167f) / 255f);

            return false;
        }
    }
}
