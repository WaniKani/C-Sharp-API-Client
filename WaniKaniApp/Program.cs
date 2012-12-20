using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClientLib;

namespace WaniKaniClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PLease enter your API key: ");
            string apiKey = Console.ReadLine();

            WaniKaniClient client = new WaniKaniClient(apiKey);

            var data2 = client.UserInformation;
            var data = client.Vocabulary();

            Console.WriteLine("Please a key to exit");
            Console.ReadKey();
        }
    }
}
