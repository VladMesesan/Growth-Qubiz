using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Growth.Controllers.ObjectOrientedProgramming
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrinciplesOfOOP : ControllerBase
    {
        [HttpGet]
        public AllTheThings GetPrinciplesOfOOP()
        {
            //ABSTRACTION----------ABSTRACTION----------ABSTRACTION
            //the user does not need to know how painting or changing channels works - he only needs to know that he can do it
            AbstractionRemote remote = new AbstractionRemote();
            remote.PaintRemote("blue");
            remote.ChangeChannel(69);


            //INHERITANCE----------INHERITANCE----------INHERITANCE
            //inheritance is not about hierarchy, it's about reusing code you've already written in another class
            InheritanceStudent student = new InheritanceStudent();
            student.Name = "Vlad";
            student.Height = 180;
            student.Gender = "male";
            student.HairColour = "black";


            //ENCAPSULATION----------ENCAPSULATION----------ENCAPSULATION
            //nobody can touch the private members of a class unless explicitly allowed
            //if you want to coomunicate with the object, you must use the methods provided
            EncapsulationCar car = new EncapsulationCar();
            car.SetModel("BMW");
            car.SetHP(190);
            car.TurnKey();
            car.GetHP(); // is the only way to get the HorsePower, can just call car.HP


            //POLYMORPHISM----------POLYMORPHISM----------POLYMORPHISM
            //Polymorphism means one name, many forms. One function behaves in different forms.
            //In other words, "Many forms of a single object is called Polymorphism."
            PolymorphismDog rex = new PolymorphismDog
            {
                Weight = 12,
                Type = "mammal",
                IsAGoodBoy = true,
                Name = "Rex",
                IsHappy = false
            };

            //METHOD OVERLOAD (Static polymorphism) - same name, different number of parameters
            //method is chosen at COMPILE TIME
            rex.PaintOnSide("Vlad");
            rex.PaintOnSide(33);
            rex.PaintOnSide(33, 66);
            rex.Pet();

            PolymorphismAnimal lion = new PolymorphismDog { };
            PolymorphismDog sissy = new PolymorphismDog { };
            sissy.Name = "Sissy";
            sissy.IsAGoodBoy = false; //since it's a girls' name
            sissy.Pet();

            //METHOD OVERRIDE (Dynamic polymorphism) - same name and number of parameters
            //we need virtual/override modifiers for this to take effect
            //method is chosen at RUNTIME
            lion.PaintOnSide("Hello"); //this will call the Animal method
            sissy.PaintOnSide("Hello DOG"); //this will call the Dog method

            Rectangle rect = new Rectangle(10, 7);
            Trace.WriteLine("Is it a rectangle? - " + rect.IsRectangle); //inheritance works the same way
            rect.WhatIsThis();
            double rectArea = rect.Area();
            Trace.WriteLine("Area: " + rectArea);

            //METHOD SHADOWING - same method in base class and child class
            //we don't need any special modifiers for shadowing, the compiler hides the function or method of the base class.
            //The child class has its own version of the function; the same function is also available in the base class.
            PolymorphismAnimal giraffe = new PolymorphismAnimal { };
            PolymorphismDog terrier = new PolymorphismDog { };

            giraffe.Pet();
            terrier.Pet();



            //Building object to be sent to UI
            AllTheThings allThings = new AllTheThings
            {
                Remote = remote,
                Student = student,
                Car = car,
                Animal = lion,
                FirstDog = rex,
                SecondDog = sissy
            };

            return allThings;
        }

        public class AbstractionRemote
        {
            private string? Colour { get; set; }
            private int? Channel { get; set; }

            public void ChangeChannel(int newChannel)
            {
                Channel = newChannel;
            }

            public void PaintRemote(string colour)
            {
                Colour = colour;
            }

            //could have some getColour or getChannel methods here to actually have access to this info as well

        }

        public class InheritanceHuman
        {
            public string Gender { get; set; }
            public string HairColour { get; set; }
        }

        public class InheritanceStudent : InheritanceHuman
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }

        public class EncapsulationCar
        {
            private string? Model { get; set; }
            private int Horsepower { get; set; }
            private bool EngineIsOn { get; set; }

            public void TurnKey()
            {
                EngineIsOn = !EngineIsOn;
            }

            public string GetModel()
            {
                return Model;
            }

            public void SetModel(string model)
            {
                Model = model;
            }

            public int GetHP()
            {
                return Horsepower;
            }

            public void SetHP(int hp)
            {
                Horsepower = hp;
            }
        }

        public class PolymorphismAnimal
        {
            public int Weight { get; set; }
            public string Type { get; set; }

            public void Pet()
            {
                Trace.WriteLine("Animal is Happy");
            }

            public virtual void PaintOnSide(string word) //or ABSTRACT if within an abstract class + no body for method - needs to be overriden in the derived class
            {
                Trace.WriteLine("You paint the word " + word + " on the side of the animal.");
            }

            public void PaintOnSide(int number)
            {
                Trace.WriteLine("You paint the number " + number + " on the side of the animal.");
            }

            public void PaintOnSide(int number, int number2)
            {
                Trace.WriteLine("You paint the numbers " + number + " AND " + number2 + " on the side of the animal.");
            }
        }

        public class PolymorphismDog : PolymorphismAnimal
        {
            public string Name { get; set; }
            public bool IsAGoodBoy { get; set; }
            public bool IsHappy { get; set; }

            public void Pet()
            {
                IsHappy = true;
                Trace.WriteLine("Is dog happy?" + IsHappy);
            }

            public override void PaintOnSide(string word)
            {
                Trace.WriteLine("You paint the word " + word + " on the side of the dog. Why...?");
            }
        }

        public class AllTheThings
        {
            public AbstractionRemote Remote { get; set; }
            public InheritanceStudent Student { get; set; }
            public EncapsulationCar Car { get; set; }
            public PolymorphismDog FirstDog { get; set; }
            public PolymorphismAnimal Animal { get; set; }
            public PolymorphismDog SecondDog { get; set; }
        }

        //You cannot create an instance of an abstract class
        //You cannot declare an abstract method outside an abstract class
        abstract class Shape
        {
            public bool IsCircle { get; set; }
            public bool IsRectangle { get; set; }
            public bool IsCube { get; set; }
            public abstract int Area();

            public abstract void WhatIsThis();
        }

        //When a class is declared sealed, it cannot be inherited; abstract classes cannot be declared sealed.
        sealed class Rectangle : Shape
        {
            private int length;
            private int width;

            public Rectangle(int length = 0, int width = 0)
            {
                this.length = length;
                this.width = width;
                IsRectangle = true;
                IsCircle = false;
                IsCube = false;
            }
            public override int Area()
            {
                Console.WriteLine("Rectangle area: ");
                return (width * length);
            }

            public override void WhatIsThis()
            {
                Trace.WriteLine("It's a rectangle, retard!");
            }
        }
    }



    //--INTERFACE--
    //An interface only allows you to define functionality, not implement it - interfaces can contain only method declarations; no method definitions
    //Methods declared in an interface must be implemented by the classes that implement the interface
    //A class can extend only one abstract class, but it can take advantage of multiple interfaces
    //The class that implements the interface should implement all its members
    //Like an abstract class, an interface cannot be instantiated

    public interface IBusinessLogic
    {
        void Initialize();
    }

    public class BusinessLogic : IBusinessLogic
    {
        public void Initialize()
        {
            //Some code
        }
    }

    //IBusinessLogic businessLogic = new BusinessLogic(); //implement interface explicitly

    public class ImplicitBusinessLogic : IBusinessLogic //implement interface implicitly
    {
        void IBusinessLogic.Initialize()
        {
        }
    }


    //--ABSTRACT CLASSES--
    //An abstract class allows you to create functionality that subclasses can implement or override - see PolymorphismAnimal
    //The methods in an abstract class can be both abstract and concrete
    //Functionality must be implemented by derived classes
    //A class can extend only one abstract class, but it can take advantage of multiple interfaces
    //Like an interface, an abstract class cannot be instantiated
}
