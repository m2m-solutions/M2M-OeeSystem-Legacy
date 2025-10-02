using System;
using System.Linq;
using Telerik.Charting;
using System.Drawing;

namespace M2M.DataCenter
{
    public class CustomPalette
    {
        public static ColorBlend[] DownTimeColors = new ColorBlend[]
                                                                    {
                                                                        new ColorBlend(new Color[]{Color.Blue, Color.LightSkyBlue}),
                                                                        new ColorBlend(new Color[]{Color.DarkGoldenrod, Color.Gold}),
                                                                        new ColorBlend(new Color[]{Color.WhiteSmoke, Color.White}),
                                                                        new ColorBlend(new Color[]{Color.Red, Color.DarkOrange}),
                                                                        new ColorBlend(new Color[]{Color.Green, Color.GreenYellow}),
                                                                        new ColorBlend(new Color[]{Color.Black, Color.DarkGray}),
                                                                        new ColorBlend(new Color[]{Color.Magenta, Color.DarkMagenta}),
                                                                        new ColorBlend(new Color[]{Color.DarkGray, Color.LightGray}),
                                                                        new ColorBlend(new Color[]{Color.Turquoise, Color.DarkTurquoise}),
                                                                        new ColorBlend(new Color[]{Color.SandyBrown, Color.Brown}),
                                                                        new ColorBlend(new Color[]{Color.Lime, Color.LimeGreen}),
                                                                        new ColorBlend(new Color[]{Color.Pink, Color.PeachPuff})
                                                                    };

        public static ColorBlend[] StateColors = new ColorBlend[]
                                                                    {
                                                                        new ColorBlend(new Color[]{Color.Green, Color.GreenYellow}),
                                                                        new ColorBlend(new Color[]{Color.Red, Color.DarkOrange}),
                                                                        new ColorBlend(new Color[]{Color.Black, Color.DarkGray})
                                                                    };

        public static Palette DownTimePalette = new Palette("DownTimePalette", DownTimeColors) { };

        public static Palette StatePalette = new Palette("StatePalette", StateColors) { };

    }
}
