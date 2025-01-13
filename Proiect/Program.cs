using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Proiect.Classes;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ConsoleWrapper>();
                    services.AddLogging(builder =>
                    {
                        builder.AddConsole();
                        builder.AddDebug();
                    });
                    services.AddTransient<ServiceAuto>();
                })
                .Build();

            var consoleWrapper = host.Services.GetRequiredService<ConsoleWrapper>();
            var serviceAuto = host.Services.GetRequiredService<ServiceAuto>();

            consoleWrapper.WriteLine("Bine ati venit in meniul aplicatiei!");

            string meniu_aplicatie = @"
        In aceasta aplicatie avem urmatoarele posibilitati:
        1. Adaugare utilizator
        2. Logare
        3. Iesire     
        ";

            consoleWrapper.WriteLine(meniu_aplicatie);
            string command = consoleWrapper.ReadLine();

            while (command != "3")
            {
                switch (command)
                {
                    case "1":
                        serviceAuto.Adaugare_Utilizator();
                        break;
                    case "2":
                        serviceAuto.Logare_Utilizator();
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }

                consoleWrapper.WriteLine(meniu_aplicatie);
                command = consoleWrapper.ReadLine();
            }

            serviceAuto.SaveDataToFile();
        }
    }
}