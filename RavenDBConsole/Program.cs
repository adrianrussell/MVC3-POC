using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Infrastructure.RavenDb;
using Model;
using Ninject;
using Raven.Client.Document;
using Services;

namespace RavenDBConsole
{
    class Program
    {
        static void Main(string[] args) {
            var kernel = new StandardKernel(new RavenModule(),new ConsoleModule(), new ServiceModule());

            var command = kernel.Get<ICreateBankersCommand>();

            command.Execute();
        }
    }
}
