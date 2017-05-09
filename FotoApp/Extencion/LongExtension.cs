using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Extension
{
    public static class LongExtension
    {
        public static string ByteToMbFotmat(this long l)
        {
            var tmp = Convert.ToDouble(l);
            tmp /= 1024;
            tmp /= 1024;
            var tmp1 = tmp.ToString(CultureInfo.InvariantCulture);
            var tmp2 = tmp1.Split('.');
            var tmp3 = tmp2.Length > 1 ? tmp2[1].Substring(0, 2) : "0";
            return $"{tmp2[0]},{tmp3} MB";
        }
        public static string ByteToMbFotmatN(this long? l)
        {
            if (l == null)
                return "0,0";
            var tmp = Convert.ToDouble(l);
            tmp /= 1024;
            tmp /= 1024;
            var tmp1 = tmp.ToString(CultureInfo.InvariantCulture);
            var tmp2 = tmp1.Split('.');
            var tmp3 = tmp2.Length > 1 ? tmp2[1].Substring(0, 2) : "0";
            return $"{tmp2[0]},{tmp3} MB";
        }
    }
}
