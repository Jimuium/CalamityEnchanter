using System.Collections.Generic;
using CalamityEnchanter.Common.ModPlayers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace CalamityEnchanter.Common.UI.HolyPoolUI
{
    // This custom UI will show whenever the player is holding the ExampleCustomResourceWeapon item and will display the player's custom resource amounts that are tracked in HolyPoolPlayer
    internal class HolyPoolBar : UIState
    {
        // For this bar we'll be using a frame texture and then a gradient inside bar, as it's one of the more simpler approaches while still looking decent.
        // Once this is all set up make sure to go and do the required stuff for most UI's in the ModSystem class.
        private UIElement area;
        private UIImage barFrame;

        public override void OnInitialize()
        {
            // Create a UIElement for all the elements to sit on top of, this simplifies the numbers as nested elements can be positioned relative to the top left corner of this element.
            // UIElement is invisible and has no padding.
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 600, 1f); // Place the resource bar to the left of the hearts.
            area.Top.Set(70, 0f); // Placing it just a bit below the top of the screen.
            area.Width.Set(182, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
            area.Height.Set(60, 0f);

            barFrame = new UIImage(
                ModContent.Request<Texture2D>("CalamityEnchanter/Common/UI/HolyPoolBarFrame")
            ); // Frame of our resource bar
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(138, 0f);
            barFrame.Height.Set(34, 0f);

            area.Append(barFrame);
            Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // This prevents drawing unless we are using an ExampleCustomResourceWeapon
            base.Draw(spriteBatch);
        }

        // Here we draw our UI
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            var modPlayer = Main.LocalPlayer.GetModPlayer<HolyPoolPlayer>();
            float quotient = (float)modPlayer.HolyPoolCurrent / modPlayer.HolyPoolMax2;
            quotient = Utils.Clamp(quotient, 0f, 1f);

            // Load the sprite sheet
            Texture2D sheetTexture = ModContent
                .Request<Texture2D>("CalamityEnchanter/Common/UI/HolyPoolBarSheet")
                .Value;

            // Number of frames (e.g., if you have frames for 5%, 10%, ..., 100%, then there are 20 frames)
            int frameCount = 58;
            int frameWidth = sheetTexture.Width / frameCount;
            int frameHeight = sheetTexture.Height;

            // Determine which frame to use
            int frameIndex = (int)(quotient * (frameCount - 1));

            // Get bar frame's position & dimensions
            Rectangle barFrameBounds = barFrame.GetInnerDimensions().ToRectangle();

            // Define the portion of the sprite sheet to draw
            Rectangle sourceRect = new Rectangle(
                frameIndex * frameWidth,
                0,
                frameWidth,
                frameHeight
            );

            // Center the bar inside the frame
            Vector2 position = new Vector2(
                barFrameBounds.X + (barFrameBounds.Width - frameWidth) / 2, // Center horizontally
                barFrameBounds.Y + (barFrameBounds.Height - frameHeight) / 2 // Center vertically
            );

            // Draw the selected frame from the sprite sheet
            spriteBatch.Draw(sheetTexture, position, sourceRect, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<HolyPoolPlayer>();
            // Setting the text per tick to update and show our resource values.
            base.Update(gameTime);
        }
    }

    // This class will only be autoloaded/registered if we're not loading on a server
    [Autoload(Side = ModSide.Client)]
    internal class HolyPoolUISystem : ModSystem
    {
        private UserInterface HolyPoolBarUserInterface;

        internal HolyPoolBar HolyPoolBar;

        public static LocalizedText HolyPoolText { get; private set; }

        public override void Load()
        {
            HolyPoolBar = new();
            HolyPoolBarUserInterface = new();
            HolyPoolBarUserInterface.SetState(HolyPoolBar);

            string category = "UI";
            HolyPoolText ??= Mod.GetLocalization($"{category}.HolyPool");
        }

        public override void UpdateUI(GameTime gameTime)
        {
            HolyPoolBarUserInterface?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer =>
                layer.Name.Equals("Vanilla: Resource Bars")
            );
            if (resourceBarIndex != -1)
            {
                layers.Insert(
                    resourceBarIndex,
                    new LegacyGameInterfaceLayer(
                        "CalamityEnchanter: HolyPoolBar",
                        delegate
                        {
                            HolyPoolBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                            return true;
                        },
                        InterfaceScaleType.UI
                    )
                );
            }
        }
    }
}
