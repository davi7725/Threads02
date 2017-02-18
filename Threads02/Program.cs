using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads02
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProg = new Program();
            myProg.Run();
        }

        private void Run()
        {
            Queue q = new Queue();
            Thread queue = new Thread(new ThreadStart(q.StartQueue));

            queue.Start();

            Clerk c = new Clerk(q,1);
            Clerk c2 = new Clerk(q,2);

            Thread clerk = new Thread(new ThreadStart(c.StartWorking));
            Thread clerk2 = new Thread(new ThreadStart(c2.StartWorking));

            clerk.Start();
            clerk2.Start();
        } 
    }
}
