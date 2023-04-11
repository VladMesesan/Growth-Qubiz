using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace Growth.Controllers.DependencyInjection
{
    public class DependencyInjection
    {
        //CONSTRUCTOR INJECTION
        //1. This is a widely used way to implement DI.
        //2. Dependency Injection is done by supplying the DEPENDENCY through the class’s constructor when creating the instance of that class.
        //3. The injected component can be used anywhere within the class.
        //4. Recommended to use when the injected dependency, you are using across the class methods.
        //5. It addresses the most common scenario where a class requires one or more dependencies.
        static void MainCI(string[] args)
        {
            //creating object
            ServiceCI1 s1 = new ServiceCI1();
            //passing dependency
            ClientCI c1 = new ClientCI(s1);
            //TO DO:
            c1.ServeMethod();

            ServiceCI2 s2 = new ServiceCI2();
            //passing dependency
            c1 = new ClientCI(s2);
            //TO DO:
            c1.ServeMethod();
        }
        //The Injection happens in the constructor, bypassing the Service that implements the IService Interface.
        //The dependencies are assembled by a "Builder" and the Builder responsibilities are as follows:
        //1. Knowing the types of each IService
        //2. According to the request, feed the abstract IService to the Client

        //PROPERTY/SETTER INJECTION
        //1. Recommended using when a class has optional dependencies, or where the implementations may need to be swapped.
        //2. Different logger implementations could be used in this way.
        //3. Does not require the creation of a new object or modifying the existing one.Without changing the object state, it could work.

        static void MainPSI(string[] args)
        {
            //creating object
            ServicePSI1 serv = new ServicePSI1();

            ClientPSI client = new ClientPSI();
            client.Service = serv; //passing dependency
            //TO DO:
            client.ServeMethod();

            ServicePSI2 s2 = new ServicePSI2();
            client.Service = s2; //passing dependency
            //TO DO:
            client.ServeMethod();
        }

        //METHOD INJECTION
        //1. Inject the dependency into a single method and generally for the use of that method.
        //2. It could be useful, where the whole class does not need the dependency, only one method having that dependency.
        //3. This is the way is rarely used.

        static void MainMI(string[] args)
        {
            //creating object
            ServiceMI1 service1 = new ServiceMI1();

            ClientMI client = new ClientMI();
            //TO DO:
            client.ServeMethod(service1);

            ServiceMI2 service2 = new ServiceMI2();
            client.ServeMethod(service2);
        }
    }


    //<-----CONSTRUCTOR INJECTION----->
    public interface IServiceCI
    {
        void Serve();
    }
    public class ServiceCI1 : IServiceCI
    {
        public void Serve()
        {
            Console.WriteLine("ServiceCI1 Called");
        }
    }
    public class ServiceCI2 : IServiceCI
    {
        public void Serve()
        {
            Console.WriteLine("ServiceCI2 Called");
        }
    }
    public class ClientCI
    {
        private IServiceCI _service;
        public ClientCI(IServiceCI service)
        {
            this._service = service;
        }
        public void ServeMethod()
        {
            this._service.Serve();
        }
    }
    //<-------------------------->

    //<-----PROPERTY/SETTER INJECTION----->
    public interface IServicePSI
    {
        void Serve();
    }
    public class ServicePSI1 : IServicePSI
    {
        public void Serve()
        {
            Console.WriteLine("ServicePSI1 Called");
        }
    }
    public class ServicePSI2 : IServicePSI
    {
        public void Serve()
        {
            Console.WriteLine("ServicePSI2 Called");
        }
    }
    public class ClientPSI
    {
        private IServicePSI _service;
        public IServicePSI Service
        {
            set { this._service = value; }
        }
        public void ServeMethod()
        {
            this._service.Serve();
        }
    }
    //<-------------------------->

    //<-----METHOD INJECTION----->
    public interface IServiceMI
    {
        void Serve();
    }
    public class ServiceMI1 : IServiceMI
    {
        public void Serve()
        {
            Console.WriteLine("Service1 Called");
        }
    }
    public class ServiceMI2 : IServiceMI
    {
        public void Serve()
        {
            Console.WriteLine("Service2 Called");
        }
    }
    public class ClientMI
    {
        public void ServeMethod(IServiceMI service)
        {
            service.Serve();
        }
    }
    //<-------------------------->
}
