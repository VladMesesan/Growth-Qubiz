using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;

namespace Growth.Controllers.ObjectOrientedProgramming
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolidController : ControllerBase
    {

    }

    //   S---S---S---S---S  -  SINGLE-RESPONSIBILITY-PRINCIPLE
    //a class should have one and only one reason to change, meaning that a class should have only one job.
    public class Square
    {
        public int Length { get; set; }
        public void RegisterSquare(string username, int length)
        {
            Square square = new Square();
            square.Length = length;

            if (username == "square")
            {
                throw new InvalidOperationException();
            }

            SqlConnection connection = new SqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [...]");//Insert square into database. 

            SmtpClient client = new SmtpClient("smtp.myhost.com");
            client.Send(new MailMessage()); //Send email. 
            //this does not follow SRP because RegisterSquare does four different jobs: create a square, register a square, connect to the database, and send an email.
            //this type of class would cause confusion in larger projects, as it is unexpected to have email generation in the same class as the registration.
            //there are also many things that could cause this code to change like if we make a switch in a database schema or if we adopt a new email API to send emails.
        }

        //instead, we need to split the class into three specific classes that each accomplish a single job.
        //here’s what our same class would look like with all other jobs refactored to separate classes:
        public void RegisterSquareSRP(string username)
        {
            if (username == "square")
                throw new InvalidOperationException();

            //_squareRepository.Insert(...);

            //_emailService.Send(...);
        }
        //This achieves the SRP because RegisterSquareSRP only registers a square and the only reason it would change is if more square restrictions are added.
        //All other behavior is maintained in the program but is now achieved with calls to squareRepository and emailService.
    }

    //   O---O---O---O---O  -  OPEN-CLOSED PRINCIPLE
    //The open-closed principle (OCP) calls for entities that can be widely adapted but also remain unchanged.
    //This leads us to create duplicate entities with specialized behavior through polymorphism.

    //The advantage of OCP is that it minimizes program risk when you add new uses for an entity.
    //Instead of reworking the base class to fit a work-in-progress feature, you create a derived class separate from the classes currently present throughout the program.

    public class Shapes
    {
        internal class Circle
        {
            public int Radius { get; set; }
        }
        // Does not follow OCP
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    area += rectangle.Width * rectangle.Height;
                }
                else
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }
            }

            return area;
        }

        public class AreaCalculator
        {
            public double Area(Rectangle[] shapes)
            {
                double area = 0;
                foreach (var shape in shapes)
                {
                    area += shape.Width * shape.Height;
                }

                return area;
            }
        }
    }
    //This program does not follow OCP because Area() is not open to extension and can only ever handle Rectangle and Circle shapes.
    //If we want to add support for Triangle, we’d have to modify the method, so it is not closed to modification.

    //We can achieve OCP by adding an abstract class Shape that all types of shapes inherit.

    public class ShapeOCP
    {
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override double Area()
            {
                return Width * Height;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            public override double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }

        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }

            return area;
        }
    }
    //Now each subtype of shape handles its own area calculation through polymorphism.
    //This opens the Shape class to extension because a new shape can easily be added with its own area calculation without error.
    //Further, nothing in the program modifies the original shape, and it will not need to be modified in the future.
    //As a result, the program now achieves the OCP principle.



    //   L---L---L---L---L  -  LISKOV SUBSTITUTION PRINCIPLE
    //The principle says that any class must be directly replaceable by any of its subclasses without error.
    //each subclass must maintain all behavior from the base class along with any new behaviors unique to the subclass.
    //The child class must be able to process all the same requests and complete all the same tasks as its parent class.
    public class NotLSP
    {
        class Program
        {
            static void Main(string[] args)
            {
                Apple apple = new Orange();
                Debug.WriteLine(apple.GetColor());
            }
        }
        public class Apple
        {
            public virtual string GetColor()
            {
                return "Red";
            }
        }
        public class Orange : Apple
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }
    }
    //This does not follow LSP because the Orange class could not replace the Apple class without altering the program output.
    //The GetColor() method is overridden by the Orange class and therefore would return that an apple is orange.

    //To change this, we’ll add an abstract class for Fruit that both Apple and Orange will implement.
    public class LSP
    {
        class Program
        {
            static void Main(string[] args)
            {
                Fruit fruit = new Orange();
                Debug.WriteLine(fruit.GetColor());
                fruit = new Apple();
                Debug.WriteLine(fruit.GetColor());
            }
        }
        public abstract class Fruit
        {
            public abstract string GetColor();
        }
        public class Apple : Fruit
        {
            public override string GetColor()
            {
                return "Red";
            }
        }
        public class Orange : Fruit
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }
    }
    //Now, any subtype (Apple or Orange) of the Fruit class can be replaced with the other subtype without error thanks to the class-specific behavior of GetColor().
    //As a result, this program now achieves the LSP principle.



    //   I---I---I---I---I  -  Interface Segregation Principle
    //This principle requires that classes only be able to perform behaviors that are useful to achieve its end functionality.
    //Classes do not include behaviors they do not use.
    //Any unused part of the method should be removed or split into a separate method.
    //The advantage of ISP is that it splits large methods into smaller, more specific methods.

    public class notISP
    {
        // Not following the Interface Segregation Principle  

        public interface IWorker
        {
            string ID { get; set; }
            string Name { get; set; }
            string Email { get; set; }
            float MonthlySalary { get; set; }
            float OtherBenefits { get; set; }
            float HourlyRate { get; set; }
            float HoursInMonth { get; set; }
            float CalculateNetSalary();
            float CalculateWorkedSalary();
        }

        public class FullTimeEmployee : IWorker
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public float MonthlySalary { get; set; }
            public float OtherBenefits { get; set; }
            public float HourlyRate { get; set; }
            public float HoursInMonth { get; set; }
            public float CalculateNetSalary() => MonthlySalary + OtherBenefits;
            public float CalculateWorkedSalary() => throw new NotImplementedException();
        }

        public class ContractEmployee : IWorker
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public float MonthlySalary { get; set; }
            public float OtherBenefits { get; set; }
            public float HourlyRate { get; set; }
            public float HoursInMonth { get; set; }
            public float CalculateNetSalary() => throw new NotImplementedException();
            public float CalculateWorkedSalary() => HourlyRate * HoursInMonth;
        }
    }
    //This program does not follow ISP because the FullTimeEmployee class does not need the CalculateWorkedSalary() function,
    //and the ContractEmployeeclass does not need the CalculateNetSalary().
    //Neither of these methods advance the goal of these classes. Instead, they are implemented because they are derived classes of the IWorker interface.

    public class ISP
    {
        // Following the Interface Segregation Principle  

        public interface IBaseWorker
        {
            string ID { get; set; }
            string Name { get; set; }
            string Email { get; set; }


        }

        public interface IFullTimeWorkerSalary : IBaseWorker
        {
            float MonthlySalary { get; set; }
            float OtherBenefits { get; set; }
            float CalculateNetSalary();
        }

        public interface IContractWorkerSalary : IBaseWorker
        {
            float HourlyRate { get; set; }
            float HoursInMonth { get; set; }
            float CalculateWorkedSalary();
        }

        public class FullTimeEmployeeFixed : IFullTimeWorkerSalary
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public float MonthlySalary { get; set; }
            public float OtherBenefits { get; set; }
            public float CalculateNetSalary() => MonthlySalary + OtherBenefits;
        }

        public class ContractEmployeeFixed : IContractWorkerSalary
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public float HourlyRate { get; set; }
            public float HoursInMonth { get; set; }
            public float CalculateWorkedSalary() => HourlyRate * HoursInMonth;
        }
    }
    //In this version, we’ve split the general interface IWorker into one base interface, IBaseWorker, and two child interfaces IFullTimeWorkerSalary and IContractWorkerSalary.
    //The general interface contains methods that all workers share.
    //The child interfaces split up methods by worker type, FullTime with a salary or Contract that gets paid hourly.
    //Now, our classes can implement the interface for that type of worker to access all methods and properties in the base class and the worker-specific interface.
    //The end classes now only contain methods and properties that further their goal and thus achieve the ISP principle.



    //   D---D---D---D---D  -  Dependency Inversion Principle
    //The dependency inversion principle (DIP) has two parts:
    //      1. High-level modules should not depend on low-level modules.Instead, both should depend on abstractions (interfaces)
    //      2. Abstractions should not depend on details.Details (like concrete implementations) should depend on abstractions.

    //To do this, we introduce an abstract interface in between.

    //'ONE'(1) reverses traditional OOP software design. Without DIP, programmers often construct programs to have high-level (less detail, more abstract) components,
    //explicitly connected with low-level (specific) components to complete tasks.
    //DIP decouples high and low-level components and instead connects both to abstractions.
    //High and low-level components can still benefit from each other, but a change in one should not directly break the other.
    //If you minimize dependencies, changes will be more localized and require less work to find all affected components.

    //'TWO'(2) can be thought of as "the abstraction is not affected if the details are changed". The abstraction is the user-facing part of the program.
    //The details are the specific behind-the-scenes implementations that cause program behavior to be visible to the user.
    //In a DIP program, we could fully overhaul the behind-the-scenes implementation of how the program achieves its behavior without the user’s knowledge.
    //This process is known as refactoring.

    public class DIP
    {
        //First, let’s create an interface with the getCustomerName() method. This will face our users.
        public interface ICustomerDataAccess
        {
            string GetCustomerName(int id);
        }

        //Now, we’ll implement details that will depend on the ICustomerDataAccess interface. Doing so achieves the second part of the DIP principle.
        public class CustomerDataAccess : ICustomerDataAccess
        {
            public CustomerDataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Dummy Customer Name";
            }
        }

        //We’ll now create a factory class that implements the abstract interface ICustomerDataAccess and returns it in a usable form.
        //The returned CustomerDataAccess class is our low-level component.
        public class DataAccessFactory
        {
            public static ICustomerDataAccess GetCustomerDataAccessObj()
            {
                return new CustomerDataAccess();
            }
        }

        //Finally, we’ll implement a high-level component CustomerBusinessLogic that also implements the interface ICustomerDataAccess.
        //Notice that our high-level component does not implement our low-level component but merely uses it.
        public class CustomerBusinessLogic
        {
            ICustomerDataAccess _custDataAccess;

            public CustomerBusinessLogic()
            {
                _custDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
            }

            public string GetCustomerName(int id)
            {
                return _custDataAccess.GetCustomerName(id);
            }
        }
    }
}
