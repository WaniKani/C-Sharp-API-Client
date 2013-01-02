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

            var studyQueue = client.StudyQueue();

            Console.WriteLine("Hello {0}", client.UserInformation().UserName);
            Console.WriteLine("You have {0} reviews and {1} new lessons.", studyQueue.ReviewsAvailable, studyQueue.LessonsAvailable);
            Console.WriteLine("You have {0} lessons in one hour and {1} within the next day.", studyQueue.ReviewsAvailableNextHour, studyQueue.ReviewsAvailableNextDay);

            Console.WriteLine("\nPlease a key to exit");
            Console.ReadKey();
        }
    }
}
