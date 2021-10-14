using System;

namespace Facad
{

    class Authorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    class Caching
    {
        public void Cache()
        {
            Console.WriteLine("Cache is Done");
        }
    }

    class Logging
    {
        public void Log()
        {
            Console.WriteLine("User Log in");
        }
    }

    class Validation
    {
        public void Validate()
        {
            Console.WriteLine("Validation process");
        }
    }


    class CrossCuttingConcerns 
    {
        public Authorize  Authorize { get; set; }
        public Caching  Caching { get; set; }
        public Logging   Logging { get; set; }
        public Validation  Validation { get; set; }

        public CrossCuttingConcerns(Authorize authorize, Caching caching, Logging logging, Validation validation)
        {
            Authorize = authorize;
            Caching = caching;
            Logging = logging;
            Validation = validation;
        }

        public void UseAll()
        {
            Authorize.CheckUser();
            Caching.Cache();
            Logging.Log();
            Validation.Validate();
        }

        public void DoSomething()
        {
            Console.WriteLine("Something");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Authorize authorize = new Authorize();
            Caching caching = new Caching();
            Logging logging = new Logging();
            Validation validation = new Validation();

            CrossCuttingConcerns concerns = new CrossCuttingConcerns(authorize, caching, logging, validation);
            concerns.UseAll();
        }
    }
}
