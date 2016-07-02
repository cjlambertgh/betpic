using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Drawing;
using betpic.Models;
using System.IO;

namespace betpic.Controllers
{
    public class ParamHolder
    {
        public string Bet { get; set; }
        public string Market { get; set; }
        public string Fav { get; set; }
        public string Dog { get; set; }
    }
    public class BetPicController : ApiController
    {

        public IHttpActionResult GetImage([FromUri] ParamHolder param)
        {
            ;
            var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\betblank3.bmp";
            var bitmap = (Bitmap)Image.FromFile(path);
            var pic = new BetPic();
            pic.Filename = "betpic_" + DateTime.Now.ToString("yyyMMddHHmmss") + ".png";
            using (var graphics = Graphics.FromImage(bitmap))
            {
                using (var font = new Font("Arial", 18, FontStyle.Bold))
                {
                    
                    graphics.DrawString(param.Bet, font, Brushes.White, new PointF(12, 102));
                    
                    graphics.DrawString(param.Fav, font, Brushes.Black, new PointF(13, 284));
                    graphics.DrawString(param.Dog, font, Brushes.Black, new PointF(13, 355));
                }

                using (var font = new Font("Arial", 14, FontStyle.Bold))
                {
                    graphics.DrawString(param.Market, font, Brushes.Black, new PointF(12, 192));
                }
            }
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //pic.ImageData = stream.ToArray();
                pic.ImageBase64 = Convert.ToBase64String(stream.ToArray());
            }

            return Ok(pic);
        }
    }
}
