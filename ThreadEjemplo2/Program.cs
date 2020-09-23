using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace ThreadEjemplo2
{
    class Program
    {
        const string path = @"";
        static void Main(string[] args)
        {
            for (int i = 0; i<250; i++)
            {
                ThreadPool.QueueUserWorkItem(CrearArchivos, i);

            }
            while (ThreadPool.PendingWorkItemCount > 0) ;
        }
        static void CrearArchivos(object data)
        {
            int i = (int)data;

            using(var sw = new StreamWriter(path +i+ "txt"))
            {
                sw.WriteLine($"Este es el hilo {Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"Hilo # {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
