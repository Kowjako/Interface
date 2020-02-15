using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    interface IProgram
    {
        int Sum();
    }
    interface IHelper
    {
        void Message();
    }
    class Mained : IProgram
    {
        int a, b;
        public Mained(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int Sum()
        {
            Message();
            return a + b;
        }
        void Message()
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Helper
    {
        public IHelper zmienna { get; set; }
        public void WriteText()
        {
            zmienna.Message();
        }
    }
    class Helper1 : IHelper
    {
        string message;
        public Helper1(string m)
        {
            message = m;
        }
        public void Message()
        {
            Console.WriteLine($"Hello [{message}]");
        }
    }
    class Helper2 : IHelper
    {
        public string message;
        public Helper2(string m)
        {
            message = m;
        }
        public void Message()
        {
            Console.WriteLine($"Hello <{message}>");
        }
    }
    class Program
    {
        static void Main()
        {
            IProgram ip = new Mained(3, 4); //UP-CAST //тут происходит реализация интерфейса
            int x = ip.Sum();
            Console.WriteLine(x);
            Helper p1 = new Helper(); 
            p1.zmienna = new Helper1("volodya"); //используем конструктор класса где есть реализация интерфейса для Хелпер1
            p1.zmienna.Message();
            p1.zmienna = new Helper2("volodya"); //используем конструктор класса где есть реализация интерфейса для Хелпер2
            p1.zmienna.Message();
            Console.Read();
        }
    }




    interface IFunc //Тут есть 2 интерфейса с одинаковыми названиями методов, если хотим реализовать по отдельности то указываем Интерфейс.Метод
    {
        void Function();
    }
    interface IFunc2
    {
        void Function();
    }
    class Function : IFunc, IFunc2
    {
        void IFunc.Function()
        {
            Console.WriteLine("Funkcja pierwszego interfejsu");
        }
        void IFunc2.Function()
        {
            Console.WriteLine("Funkcja drugiego interfejsu");
        }
    }
}
