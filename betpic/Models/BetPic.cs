using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace betpic.Models
{
    public class BetPic
    {
        public string Filename { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageBase64 { get; set; }
    }
}