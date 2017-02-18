using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads02
{
    class Queue
    {
        public List<int> peopleQueue { get; set; }
        public int NextIdToPick { get; set; }

        private Object lockerz = new Object();

        internal int GetNextIdToPick()
        {
            lock(lockerz)
            {
                int numberToReturn = NextIdToPick;
                NextIdToPick++;
                return numberToReturn;
            }
        }

        public void StartQueue()
        {
            peopleQueue = new List<int>();
            NextIdToPick = 1;
            for (int i = 1; i < 20; i++)
            {
                peopleQueue.Add(i);
                Console.WriteLine("The next issue to be picked: " + (i + 1));
                Thread.Sleep(2000);
            }
        }
        
    }
}
