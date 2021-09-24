using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Sprites.SpriteFactory
{
    public class SpriteDataArray
    {
        public SpriteData[] Value { get; set; }
      //  public List<SpriteData> Value1 { get; set; }

    }
    
    public class SpriteData
    {
        public String SpriteName { get; set; }
        public String SpriteSheet { get; set; }
        public int[] Data { get; set; }
    }
}
