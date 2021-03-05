using System.Collections.Generic;

namespace CrossyRoadHack
{
    public class gamedata
    {

         public class C
        {
            public string id { get; set; }//Skin ID
            public bool un { get; set; }//Unlocked
            public int pl { get; set; }
            public bool pa { get; set; }
            public int pr { get; set; }
            public bool vr { get; set; }
            public bool tu { get; set; }

        }

        public class Root
        {
            public List<C> cs { get; set; }//Characters
            public long hs { get; set; }//Highscore
            public int ds { get; set; }
            public int ps { get; set; }
            public int yg { get; set; }
            public int du { get; set; }
            public long cc { get; set; }//Coins 
            public bool pb { get; set; }
            public object ch { get; set; }
            public object dh { get; set; }
        }


    }
}
