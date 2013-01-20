using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Car.Fetcher.Services;

namespace Bizis.Site.Car.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            _MakerLoad();
            
            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static void _MakerLoad()
        {
            new CarSifLoader().Load();
        }
    }
}
