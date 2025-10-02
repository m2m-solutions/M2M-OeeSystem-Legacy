using System;

using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace M2M.DataCenter.WebUI.Production
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int ix = Convert.ToInt32(context.Request.QueryString["ix"]);
            // if ix larger than number of colors, start over from 0
            int index = ix % CustomPalette.DownTimeColors.Count();
            if (index < CustomPalette.DownTimeColors.Count())
            {
                using (Bitmap bitmap = new Bitmap(12, 12, PixelFormat.Format32bppArgb)) 
                {
                    
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.Clear(Color.Transparent);

                        using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                                    new Rectangle(0, 0, 12, 12),
                                    CustomPalette.DownTimeColors[index][0].Color,
                                    CustomPalette.DownTimeColors[index][1].Color,
                                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                        {

                            

                            
                            graphics.FillEllipse(brush, new Rectangle(1, 1, 10, 10));
                            graphics.DrawEllipse(Pens.Gray, new Rectangle(1, 1, 10, 10));
                            context.Response.ContentType = "image/png";
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                ms.WriteTo(context.Response.OutputStream);
                            }
                        }
                    }
                }
            }
            
   
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}