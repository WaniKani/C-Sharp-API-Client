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

            var data = client.RecentUnlocks(50);

            var data2 = client.UserInformation;

            Console.WriteLine("Please a key to exit");
            Console.ReadKey();
        }
    }
}
