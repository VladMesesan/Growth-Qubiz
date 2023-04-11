using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using Unity;

namespace Growth.Controllers.DependencyInjection
{
    [Route("api/[controller]")]
    [ApiController]
    //It's a DESIGN PRINCIPLE
    //The main objective of IoC is to remove the dependencies between the objects of an application which makes the application more decoupled and maintainable.
    public class InversionOfControl : ControllerBase
    {
        //The IoC Design Principle suggests the inversion of various types of controls in object-oriented design to achieve loose coupling between the application classes.
        //Here, control means any extra responsibilities a class has other than its main or fundamental responsibility.

        void Main()
        {
            // the order of our registration does not matter.
            var container = new UnityContainer();
            container.RegisterType<IDependencyIOC1, DependencyIOC1>();
            container.RegisterType<IDependencyIOC2, DependencyIOC2>();
            container.RegisterType<IClassIOC, ClassIOC>();

            // then we request our first object like in the first example (MyClass);
            var classIOC = container.Resolve<IClassIOC>();

            classIOC.Run();

            //The container will handle wiring up all the dependencies. So we never need to pass DepedencyIOC2 to ClassIOC and then to DepedencyIOC1.
            //We only need to request it in DependencyIOC1 and the container will wire it up for us.
        }
    }

    public class College
    {
        //Both classes are tightly coupled with each other.
        //I cannot have a College without TechEvents because a TechEvents object is created in a College Constructor.

        //If I make any changes to TechEvents, I need to compile, or you can say update College too.

        //College controls the creation of Events.
        //College is aware of the single event that is organized. Suppose there is any specific event to be organized like Weekend FootballEvent or PartyEvent.
        //In that case, a College class needs to be changed as College directly refers to Events.
        private TechEvents _events = null;
        
        public College()
        {
            _events = new TechEvents();
        }

        public void GetEvents()
        {
            _events.LoadEventDetails();
        }
    }

    class TechEvents
    {
        public void LoadEventDetails()
        {
            Trace.WriteLine("Event Details");
        }
    }

    //The solution could be to shift the control of the event's organization to some other place.
    //This is Inversion of Control (IOC), inverting the control to another entity instead of directly organizing the event in College.



    //What does the Inversion of control principle say?
    //Don't call us; we will call you.
    //In other words, the Main class should not have a concrete implementation of an aggregated class, rather,
    //it should depend on the abstraction of that class.
    //The College class should depend on TechEvents class abstraction using an interface or abstract class.
    interface IEvent
    {
        void LoadEventDetails();
    }

    class TechEventsIOC : IEvent
    {
        public void LoadEventDetails()
        {
            Trace.WriteLine("Event Details");
        }
    }

    class FootballEventIOC : IEvent
    {
        public void LoadEventDetails()
        {
            Trace.WriteLine("Football Event");
        }
    }

    class PartyEventIOC : IEvent
    {
        public void LoadEventDetails()
        {
            Trace.WriteLine("Party Event");
        }
    }

    class CollegeIOC
    {
        //Injection via Property
        //This is the most commonly used methodology where we inject the concrete class by creating a property whose type is the interface.
        private IEvent _events = null;
        EventLocator el = new EventLocator();

        //Injection via Constructor
        //the object of the concrete class is passed to the constructor of the dependent class.
        public CollegeIOC(IEvent ie)
        {
            _events = ie;
        }

        //Injection via Service Locator
        //A service locator can act like a simple runtime mapper.
        //This allows code to be added at runtime without re-compiling the application and sometimes without restarting it.
        public CollegeIOC(int index)
        {
            this._events = el.LocateEvent(index);
        }

        public void GetEvents()
        {
            _events.LoadEventDetails();
        }

        //Injection via Method
        //This methodology passes the concrete class object through the method parameter to the dependent class.
        public void GetEventViaMethod(IEvent myevent)
        {
            _events = myevent;

        }

        //The EventLocator class, between the Events and College, helps us locate the service without knowing the concrete type.
        //Hence any changes to EventLocator will not affect the College class.
        //I am just passing the index value in the constructor that, in turn, calls the third party to locate the event and return it to the constructor.
        class EventLocator
        {
            public IEvent LocateEvent(int index)
            {
                if (index == 1)
                    return new FootballEventIOC();
                else if (index == 2)
                    return new PartyEventIOC();
                else
                    return new TechEventsIOC();
            }
        }
    }

    //IOC can be done using Dependency Injection (DI)
    //It explains how to inject concrete implementation into a class using abstraction, in other words, an interface inside

    //There are four ways of achieving Dependency Injection.
    //1. Injection via Constructor
    //2. Injection via Property
    //3. Injection via Method
    //4. Injection via Service Locator
    //SEE ABOVE


    //Advantages of implementing this principle:
    //A) It helps in class decoupling.
    //B) Due to decoupling, the reusability of the code is increased.
    //C) Improved code maintainability and testing.

    //Inversion of control (IOC) talks about who will initiate the call;
    //Dependency Injection (DI) talks about how one object acquires dependency on another object through abstraction. 



    //IoC Container
    //IoC Container (DI Container) is a framework for implementing automatic dependency injection.
    //It manages object creation and it's life-time, and also injects dependencies to the class.

    public class Class
    {
        public void Run()
        {
            var dependency = new Dependency1();
            dependency.DoSomething();
        }
    }

    public class Dependency1
    {
        public void DoSomething()
        {
            var dependency = new Dependency2();
            dependency.DoSomethingElse();
        }
    }

    public class Dependency2
    {
        public void DoSomethingElse()
        {
        }
    }

    //Not IOC
    // MyClass -> Dependency1 -> Dependency2.

    //The first thing we should do is refactor the classes to take their dependencies through their constructor and rely on interfaces rather than concretions.
    //We can't inject dependencies unless there is a place to inject them (constructor, property, etc).

    public interface IClassIOC
    {
        void Run();
    }

    public interface IDependencyIOC1
    {
        void DoSomething();
    }

    public interface IDependencyIOC2
    {
        void DoSomethingElse();
    }

    public class ClassIOC : IClassIOC
    {
        public readonly IDependencyIOC1 dep;

        public ClassIOC(IDependencyIOC1 dep)
        {
            this.dep = dep;
        }

        public void Run()
        {
            this.dep.DoSomething();
        }
    }

    public class DependencyIOC1 : IDependencyIOC1
    {
        public IDependencyIOC2? dep;

        public void ClassIOC(IDependencyIOC2 dep)
        {
            this.dep = dep;
        }

        public void DoSomething()
        {
            dep?.DoSomethingElse();
        }
    }

    public class DependencyIOC2 : IDependencyIOC2
    {
        public void DoSomethingElse()
        {
        }
    }

    //Classes now all take their dependencies through their constructors.
    //Classes should only take in dependencies that they actually need. For example, MyClass does not NEED a Dependency2 so it doesn't ask for one.
    //It only asks for a Dependency1 because that's all it needs. Dependency1 NEEDS Dependency2, not MyClass.

    //Now to wire it all up WITHOUT a container we would just new it all up in the composition root:
    // var myClass = new ClassIOC(new DependencyIOC1(new DependencyIOC2()));

    //That could get cumbersome if we had tons of classes and depdencies.
    //That's why we use a container. It handles all the depdency graph for us.
    //With a container we'd rewrite it as follows: SEE LINE 16
}
