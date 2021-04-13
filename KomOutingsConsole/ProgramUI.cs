using KomOutings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomOutingsConsole
{
    public class ProgramUI
    {
        private OutingsRepo _repo = new OutingsRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Company Outings Management Software\n" +
                    "Select an option: \n\n" +
                    "1. Display all company outings\n" +
                    "2. Display outings by event\n" +
                    "3. Add a company outing\n" +
                    "0. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayOutings();
                        break;
                    case "2":
                        DisplayOutingCostByEvent();
                        break;
                    case "3":
                        AddOuting();
                        break;
                    case "0":
                        Console.WriteLine("Thank you for using\n" +
                            "Komodo Company Outings Management Software\n" +
                            "Copyright 2021\n" +
                            "Written by Josh Denman\n" +
                            "All Rights Reserved\n\n" +
                            "Press any key to exit");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }

        private void DisplayOutingCostByEvent()
        {
            Console.Clear();
            Console.WriteLine($"Total cost for amusment parks: {_repo.TotalCostForEventType(EventType.AmusementPark)} ");
            Console.WriteLine($"Total cost for bowling: {_repo.TotalCostForEventType(EventType.Bowling)} ");
            Console.WriteLine($"Total cost for golf: {_repo.TotalCostForEventType(EventType.Golf)} ");
            Console.WriteLine($"Total cost for concert: {_repo.TotalCostForEventType(EventType.Concert)} ");
            Console.ReadKey();

        }

        private void AddOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();
            Console.WriteLine("What is the event type?\n" +
                "1. Amusement Park\n" +
                "2. Bowling\n" +
                "3. Golf\n" +
                "4. Concert");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newOuting.EventType = EventType.AmusementPark;
                    break;
                case "2":
                    newOuting.EventType = EventType.Bowling;
                    break;
                case "3":
                    newOuting.EventType = EventType.Golf;
                    break;
                case "4":
                    newOuting.EventType = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-4");
                    break;
            }

            Console.WriteLine("How many people attended?");
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());
            newOuting.NumberOfPeople = numberOfPeople;

            Console.WriteLine("What is the date of the event?(YYYY,MM,DD): ");
            DateTime eventDate = Convert.ToDateTime(Console.ReadLine());
            newOuting.Date = eventDate;

            Console.WriteLine("How much did the event cost?: ");
            string cost = Console.ReadLine();
            if (cost.Contains("$"))
            {
                cost = cost.Replace("$", string.Empty);
            }
                newOuting.TotalCostForEvent = Convert.ToDouble(cost);

            _repo.AddOuting(newOuting);
        }

        public void DisplayOutings()
        {
            Console.Clear();
            List<Outing> allOutings = _repo.GetAllOutings();

            Console.WriteLine($"\n{"Event Type",-25} {"Attendance",-15} {"Date",-10} {"Total Cost",-15} {"Cost Per Person",-10}\n");
            foreach (Outing outing in allOutings)
            {
                Console.WriteLine($"{outing.EventType,-25} {outing.NumberOfPeople,-15} {outing.Date.ToShortDateString(),-10} ${outing.TotalCostForEvent,-15} ${outing.TotalCostPerPerson,-10}");
            }
            double totalCost = _repo.TotalCost();

            Console.WriteLine($"\nTotal cost for all events: ${totalCost}");
            Console.ReadKey();

        }

        private void SeedContentList()
        {
            Outing Outing1 = new Outing(EventType.Bowling, 5, new DateTime(2021, 4, 10), 50.00);
            Outing Outing2 = new Outing(EventType.Concert, 50, new DateTime(2021, 4, 09), 1000.00);
            Outing Outing3 = new Outing(EventType.AmusementPark, 40, new DateTime(2021, 4, 08), 2000.00);
            Outing Outing4 = new Outing(EventType.Golf, 10, new DateTime(2021, 4, 07), 400.00);
            Outing Outing5 = new Outing(EventType.AmusementPark, 30, new DateTime(2021, 4, 06), 1650.00);
            _repo.AddOuting(Outing1);
            _repo.AddOuting(Outing2);
            _repo.AddOuting(Outing3);
            _repo.AddOuting(Outing4);
            _repo.AddOuting(Outing5);
        }
    }
}
