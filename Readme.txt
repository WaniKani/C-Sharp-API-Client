C-Sharp-API-Client
This is a simple API Client for WaniKani to speed up projects writen in .NET

How to use:
Include the dll or code into your project.

To Create a client.
var client = new WaniKaniClient("theApiKey");

To get the latest study queue Information
var studyQueue = client.StudyQueue();

With that you can example see how many reviews you got left.
Console.WriteLine("You have {0} reviews and {1} new lessons.", studyQueue.ReviewsAvailable, studyQueue.LessonsAvailable);

The API got full XML documentation for every public method and pretty self explained.