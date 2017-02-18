using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads02
{
    class Clerk
    {
        private Queue mainQueue;
        private int clerkId;

        public Clerk(Queue q, int id)
        {
            mainQueue = q;
            clerkId = id;
        }

        public void StartWorking()
        {
            bool working = true;

            while(working)
            {
                int nextNr = mainQueue.GetNextIdToPick();
                Console.WriteLine("Clerk("+clerkId+") is now handling: " + nextNr);
                Thread.Sleep(5000);
                //Console.WriteLine(mainQueue.peopleQueue[mainQueue.peopleQueue.Count - 1] + " " + nextNr);
                while(mainQueue.peopleQueue[mainQueue.peopleQueue.Count - 1] <= nextNr)
                { 
                    GoToSleep();
                }
            }
        }

        private void GoToSleep()
        {
            Console.WriteLine("I am now resting!! btw im clerk " + clerkId);
            Thread.Sleep(2000);
        }
    }
}
