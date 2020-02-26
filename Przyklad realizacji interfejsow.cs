using System;
using System.Reflection;

namespace ConsoleApplication3
{
    interface IEngine
    {
        void Start();
        void Stop();
        int Weight { get; }
        int Power { get; }
    }
    class RocketHeader
    {
        public int Cosmonauts { get; private set; }
        public int MassShell { get; private set; }
        public RocketHeader()
        {
            Cosmonauts = 3;
            MassShell = 5000;
        }
        public int GetWeight()
        {
            return (Cosmonauts * 80) + MassShell;
        }
        public void SendMessage(string mes)
        {
            Console.WriteLine("Wysylam...");
            Console.WriteLine(mes);
            Console.WriteLine("Wyslane...");
        }

    }
    class Rocket
    {
        public RocketHeader Header { get; set; }
        public IEngine Engine { get; set; }
        public int Weight
        {
            get
            {
                return Header.GetWeight() + Engine.Weight;
            }
        }
    }
    class EnergyEngine : IEngine
    {
        public int Power { get; }
        public int Weight { get; }
        public EnergyEngine(int power, int weight)
        {
            Power = power;
            Weight = weight;
        }
        public void Start()
        {
            Console.WriteLine("Silnik energetyczny aktywowany");
        }
        public void Stop()
        {
            Console.WriteLine("Silnik eneregetyczny zatrzymany");
        }
    }
    class AtomicEngine : IEngine
    {
        public int Power { get; }
        public int Weight { get; }
        public AtomicEngine(int power, int weight)
        {
            Power = power;
            Weight = weight;
        }
        public void Start()
        {
            Console.WriteLine("Silnik atomowy aktywowany");
        }
        public void Stop()
        {
            Console.WriteLine("Silnik atomowy zatrzymany");
        }
    }
    class Program
    {
        static void Main()
        {
            Rocket rocket = new Rocket();    
            rocket.Header = new RocketHeader();
            /* */
            rocket.Engine = new AtomicEngine(5000, 250);
            rocket.Engine.Start();
            Console.WriteLine(rocket.Weight);
            rocket.Engine.Stop();
            /* */
            rocket.Engine = new EnergyEngine(2000, 10);
            rocket.Engine.Start();
            Console.WriteLine(rocket.Weight);
            rocket.Engine.Stop();
            /* */
            Console.ReadKey();
        }
    }
}

