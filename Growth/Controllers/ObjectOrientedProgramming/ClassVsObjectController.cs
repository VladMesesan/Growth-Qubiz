using Microsoft.AspNetCore.Mvc;

namespace Growth.Controllers.ObjectOrientedProgramming
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClassVsObjectController : ControllerBase
    {
        [HttpGet]
        public ClassObjectExample GetClassObjectExample()
        {
            Random rnd = new Random();
            int randomNum = rnd.Next();

            //OBJECT is an instance of class by which we can access the data members and member functions of the class.
            //An object in OOP is a component which consists of properties to make a particular data useful.
            ForExample forExample = new ForExample { Name = "JustAnExample", RandomNumber = randomNum };

            ClassObjectExample classExample = new ClassObjectExample() { IntProperty = 1, StringProperty = "Also one", ForExample = forExample };

            return classExample;
        }

        //CLASS is a user-defined datatype that has its own data members and member functions.
        //The member functions and data members can be accessed with the help of objects.
        //A class is used to organize information or data so a programmer can reuse the elements in multiple instances.
        public class ClassObjectExample
        {
            public int IntProperty { get; set; }
            public string? StringProperty { get; set; }
            public ForExample? ForExample { get; set; }

        }

        public class ForExample
        {
            public string? Name { get; set; }
            public int RandomNumber { get; set; }
        }
    }
}
