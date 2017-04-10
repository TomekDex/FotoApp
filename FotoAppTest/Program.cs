using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FotoAppDBTest;

namespace FotoAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FotoAppRAll cos = FotoAppRAll.Ins;

            var cos1 = cos.Types.GetAll(true);
            var cos2 = cos.Sizes.GetSizesByType(cos1[0], true);
            Console.ReadKey();
        }
    }
}
