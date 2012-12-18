using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClient;

namespace WaniKaniApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WKClient client = new WKClient("114023cc08517f6180a1f120bfffe87f");

            var data = client.GetUserInformation();

            Console.WriteLine("Please a key to exit");
            Console.ReadKey();
        }
    }
}
