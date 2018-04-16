using System;

namespace WPFClient
{
    public class Servo
    {
        public Byte CanAddr{ get; set; }
        public Int16 Position{ get; set; }
        public Int32 Mode{ get; set; }
    }
}
