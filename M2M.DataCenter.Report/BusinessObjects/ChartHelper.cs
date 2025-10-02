using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting.Charting;
using System.Drawing;

namespace M2M.DataCenter
{
    public static class ChartHelper
    {
        private static readonly PaletteItemsCollection m_CustomPalette = new PaletteItemsCollection()
        {
            new PaletteItem(Color.Red, Color.DarkOrange),
            new PaletteItem(Color.Blue, Color.LightSkyBlue),
            new PaletteItem(Color.Green, Color.GreenYellow),
            new PaletteItem(Color.DarkGoldenrod, Color.Gold),
            new PaletteItem(Color.WhiteSmoke, Color.White),
            new PaletteItem(Color.DarkGray, Color.LightGray),
            new PaletteItem(Color.Black, Color.DarkGray),
            new PaletteItem(Color.Magenta, Color.DarkMagenta),
            new PaletteItem(Color.Turquoise, Color.DarkTurquoise),
            new PaletteItem(Color.SandyBrown, Color.Brown),
            new PaletteItem(Color.Lime, Color.LimeGreen),
            new PaletteItem(Color.Pink, Color.PeachPuff)
        };

        public static PaletteItem[] GetPalette(Dictionary<string, int> paletteMapper)
        {
            PaletteItemsCollection paletteItems = new PaletteItemsCollection();
            
            foreach(KeyValuePair<string, int> mapItem in paletteMapper)
            {
                paletteItems.Add(m_CustomPalette[mapItem.Value]);
            }

            return paletteItems.ToArray<PaletteItem>();
        }


        public static int GetFirstAvailableIndex(Dictionary<string, int> paletteMapper, Dictionary<string, int> newPaletteMapper)
        {
            for (int i = 0; i < 11; i++)
            {
                if (!paletteMapper.ContainsValue(i) && !newPaletteMapper.ContainsValue(i))
                    return i;
            }

            return 11;
        }
    }
}
