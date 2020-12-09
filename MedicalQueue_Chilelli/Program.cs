using System;
using System.Threading;

namespace MedicalQueue_Chilelli
{
    class Program
    {
        static void Main(string[] args)
        {
            ERQueue eRQ = new ERQueue();
            bool running = true;
            while (running)
            {
                Console.WriteLine(Words.mainMenu);
                ConsoleKey menuInput = Console.ReadKey(true).Key;
                menuOfStuff(eRQ, menuInput);
            }
        }
        public static void menuOfStuff(ERQueue eRQ, ConsoleKey menuInput)
        {
            switch (menuInput)
            {
                case ConsoleKey.A:
                    {
                        int listSize;
                        string name;
                        int prio;
                        Console.WriteLine(Words.needInfo);
                        Console.Write(Words.patientName); name = Console.ReadLine();
                        Console.Write(Words.patientPrio); string priority = Console.ReadKey().KeyChar.ToString();
                        while (!Int32.TryParse(priority, out prio) || (prio <= 0 || prio > 5))
                        {
                            Console.WriteLine(Words.incorrect);
                            Console.Write(Words.patientPrio);
                            priority = Console.ReadKey().KeyChar.ToString();
                        }
                        Patient newP = new Patient(name, prio);
                        listSize = eRQ.Enqueue(newP);

                        if (listSize == -1)
                        {
                            Console.WriteLine(Words.listFull);
                        }
                        else
                        {
                            Console.WriteLine("\nThere are " + listSize + " in patients the queue");
                        }
                        break;
                    }
                case ConsoleKey.P:
                    {
                        string beingRemoved = eRQ.Dequeue();
                        if (beingRemoved == Words.incorrect)
                        {
                            Console.WriteLine(Words.incorrect);
                        }
                        else
                        {
                            Console.WriteLine("Removing: " + beingRemoved);
                        }
                        break;
                    }
                case ConsoleKey.L:
                    {
                        if (eRQ.limitSize() <= 0)
                        {
                            Console.WriteLine(Words.incorrect);
                        }
                        Console.WriteLine(eRQ.ToString());
                        break;
                    }
                case ConsoleKey.Q:
                    {
                        Console.Clear();
                        Console.WriteLine("No more patients? See ya tomorrow doc!");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine(Words.incorrect);
                        break;
                    }
            }
        }
    }
}
