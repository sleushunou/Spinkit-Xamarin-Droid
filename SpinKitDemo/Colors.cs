using System;
namespace SpinKitDemo
{
    public static class Colors
    {
        static Colors()
        {
            Values = new uint[]{
                0XFFD55400,
                0XFF2B3E51,
                0XFF00BD9C,
                0XFF227FBB,
                0XFF7F8C8D,
                0XFFFFCC5C,
                0XFFD55400,
                0XFF1AAF5D,
            };
        }

        public static uint[] Values { get; private set; }
    }
}
