using System;
using System.Collections.Generic;
using System.Linq;

namespace TumakovSB
{
    class QueueManager
    {
        #region Fields
        private Stack<Citizen> citizens;
        private Queue<Citizen> heatingQueue;
        private Queue<Citizen> paymentQueue;
        private Queue<Citizen> otherQueue;
        #endregion

        #region Constructors
        public QueueManager()
        {
            citizens = new Stack<Citizen>();
            heatingQueue = new Queue<Citizen>();
            paymentQueue = new Queue<Citizen>();
            otherQueue = new Queue<Citizen>();
        }
        #endregion

        #region Methods
        public void AddCitizenToQueue(Citizen citizen)
        {
            citizens.Push(citizen);
        }

        public void ProcessQueue()
        {
            while (citizens.Count > 0)
            {
                Citizen current = citizens.Pop();
                AssignToWindow(current);
            }
        }

        private void AssignToWindow(Citizen citizen)
        {
            if (citizen.temperament.intelligence == 0)
            {
                Random rnd = new Random();
                int randomWindow = rnd.Next(1, 4);
                AssignToRandomWindow(citizen, randomWindow);
                return;
            }

            switch (citizen.problem)
            {
                case Problem.Отопление:
                    InsertIntoQueue(citizen, heatingQueue);
                    break;
                case Problem.Оплата:
                    InsertIntoQueue(citizen, paymentQueue);
                    break;
                case Problem.Другое:
                    InsertIntoQueue(citizen, otherQueue);
                    break;
            }
        }

        private void AssignToRandomWindow(Citizen citizen, int window)
        {
            switch (window)
            {
                case 1:
                    heatingQueue.Enqueue(citizen);
                    break;
                case 2:
                    paymentQueue.Enqueue(citizen);
                    break;
                case 3:
                    otherQueue.Enqueue(citizen);
                    break;
            }
        }

        private void InsertIntoQueue(Citizen citizen, Queue<Citizen> queue)
        {
            if (citizen.temperament.scandalousness >= 5)
            {
                Console.WriteLine($"{citizen.name} (скандальный) спрашивает, сколько человек обогнать.");
                Console.Write("Введите количество людей для обгона: ");
                int skip;
                if (int.TryParse(Console.ReadLine(), out skip) && skip > 0)
                {
                    List<Citizen> temp = queue.ToList();
                    queue.Clear();
                    queue.Enqueue(citizen);
                    foreach (var person in temp.Skip(skip))
                    {
                        queue.Enqueue(person);
                    }
                    foreach (var person in temp.Take(skip))
                    {
                        queue.Enqueue(person);
                    }
                    return;
                }
            }
            queue.Enqueue(citizen);
        }

        public void PrintQueues()
        {
            Console.WriteLine("\nОчередь на отопление:");
            PrintQueue(heatingQueue);
            Console.WriteLine("\nОчередь на оплату:");
            PrintQueue(paymentQueue);
            Console.WriteLine("\nОчередь на другие проблемы:");
            PrintQueue(otherQueue);
        }

        private void PrintQueue(Queue<Citizen> queue)
        {
            foreach (var citizen in queue)
            {
                citizen.PrintInfo();
            }
        }
        #endregion
    }
}
