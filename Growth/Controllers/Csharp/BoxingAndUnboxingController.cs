using Microsoft.AspNetCore.Mvc;

namespace Growth.Controllers.Csharp
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BoxingAndUnboxingController : ControllerBase
    {
        static void SimpleExample()
        {
            int i = 100;

            object obj = i; //Boxing

            i = (int)obj; //Unboxing
        }

        public List<object> BoxingAndUnboxing()
        {
            List<object> mixedList = new List<object>(); // random list of random objects

            mixedList.Add("First Group: "); // adding a string
            for (int j = 1; j < 5; j++) // adding some ints
            {
                // Each element j is boxed when we add it to mixedList.
                mixedList.Add(j);
            }

            mixedList.Add("<br>Second Group: "); // adding another string
            for (int j = 5; j < 10; j++) // adding some more ints
            {
                // Each element j is boxed when we add it to mixedList, same as before
                mixedList.Add(j);
            }

            foreach (var item in mixedList) //just checking the objects
            {
                Console.WriteLine(item); //items are objects here
            }

            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // sum += mixedList[j] * mixedList[j]; - this would throw an error
                sum += (int)mixedList[j] * (int)mixedList[j]; // but it works if we unbox them first
            } 
            //Sum = (1 * 1) + (2 * 2) + (3 * 3) + (4 * 4) = 30

            mixedList.Add("<br>SUM: " + sum);

            return mixedList;
        }
    }
}
