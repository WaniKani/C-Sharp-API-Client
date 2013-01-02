C-Sharp-API-Client
This is a simple API Client for WaniKani to speed up projects written in .NET
Current API version is 1.1

How to use:
Include the dll or code into your project.

To create a client.
var client = new WaniKaniClient("theApiKey");

To get the latest study queue Information
var studyQueue = client.StudyQueue();

With that you can example see how many reviews you got left.
Console.WriteLine("You have {0} reviews and {1} new lessons.", studyQueue.ReviewsAvailable, studyQueue.LessonsAvailable);

The API got full XML documentation for every public method and pretty self explained.

This API will give out the same information + a few helper functions from the WaniKani API, to see exactly
what information you can retrieve I recommend you to check out the API  manual found here http://www.wanikani.com/api
