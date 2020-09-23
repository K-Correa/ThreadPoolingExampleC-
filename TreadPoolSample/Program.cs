using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace TreadPoolSample
{
    class Program
    {
        const string path =@"";
        static void Main(string[] args)
        {
            
            //int max, c = 0;
            //ThreadPool.GetMaxThreads(out max, out c);
            //Console.WriteLine(max);

            for(int i = 0; i<50; i++)
            {
                ThreadPool.QueueUserWorkItem(Create, i);
            }
            // Este while mantiene trabajando a el programa mientras haya tareas pendientes w
            while (ThreadPool.PendingWorkItemCount > 0);
        }

        static void Create(object data)
        {
            int i = (int)data;
            using (var sw = new StreamWriter(path +i+"txt"))
            {
               sw.WriteLine($"Este es el hilo {Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId} ");

        }
    }
}
