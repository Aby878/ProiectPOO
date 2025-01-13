using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proiect.Classes;

namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<ConsoleWrapper>();
                services.AddTransient<ServiceAuto>();
            })
            .Build();

        var consoleWrapper = host.Services.GetRequiredService<ConsoleWrapper>();
        var serviceAuto = host.Services.GetRequiredService<ServiceAuto>();
        Console.WriteLine("Bine ati venit in meniul aplicatiei!");
       

        string meniu_aplicatie = @"
        In aceasta aplicatie avem urmatoarele posibilitati:
        1. Adaugare utilizator
        2. Logare
        3. Iesire     
        ";

        consoleWrapper.WriteLine(meniu_aplicatie);
        string command = Console.ReadLine();

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
            command = Console.ReadLine();
                        
        }
        serviceAuto.SaveDataToFile();

    }
}