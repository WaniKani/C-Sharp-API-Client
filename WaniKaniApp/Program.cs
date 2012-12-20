using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClientLib;

namespace WaniKaniApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WaniKaniClient client = new WaniKaniClient("114023cc08517f6180a1f120bfffe87f");

            var data2 = client.UserInformation;

            var data = client.Vocabulary();

            Console.WriteLine("Please a key to exit");
            Console.ReadKey();
        }
    }
}
