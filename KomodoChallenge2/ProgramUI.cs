using BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgesConsole
{
    public class ProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            DictionarySeed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("KOMODO BADGE SECURITY MANAGEMENT\n\n" +
                    "Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "0. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "0":
                        Console.WriteLine("\nThank you for using\n" +
                            "KOMODO BADGE SECURITY MANAGEMENT\n" +
                            "Copyright 2021\n" +
                            "Written by R Ross Denman II\n" +
                            "All Rights Reserved\n\n" +
                            "Press any key to exit");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please Press Any Key to Continue...");
                Console.ReadKey();
            }
        }

        public void AddNewBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge:");
            double newBadgeID = Convert.ToDouble(Console.ReadLine());
            List<Door> doorList = WhileList();
            _repo.AddBadgeToDictionary(newBadgeID, doorList);
        }
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");

            double badgeID = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"{badgeID} has access to door(s) {string.Join(", ", _repo._badgeDictionary[badgeID])}.\n\n" +
                $"What would you like to do?\n" +
                $"\t1. Remove a door\n" +
                $"\t2. Add a door\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Write("Which door would you like to remove:");
                    string doorToRemove = Console.ReadLine().ToUpper();

                    if (Enum.IsDefined(typeof(Door), doorToRemove))
                    {
                        Door removeDoor = (Door)Enum.Parse(typeof(Door), doorToRemove);
                        if (_repo._badgeDictionary[badgeID].Contains(removeDoor))
                        {
                            _repo.removeRoomFromBadge(badgeID, removeDoor);
                            //_repo._badgeDictionary[badgeID].Remove(removeDoor);
                            Console.WriteLine($"{removeDoor} successfully removed");
                        }
                        else
                        {
                            Console.WriteLine($"{removeDoor} is not assigned to {badgeID}.");
                        }
                    }
                    else
                    { Console.WriteLine("Invalid Entry"); }
                    break;
                case "2":
                    List<Door> doorList = WhileList();
                    _repo._badgeDictionary[badgeID].AddRange(doorList);
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
        }
        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<double, List<Door>> allBadges = _repo.GetAllBadges();
            Console.WriteLine($"Key\n" +
                $"{"Badge #",-15} Door Access\n");

            foreach (KeyValuePair<double, List<Door>> kvp in allBadges)
            {
                Console.WriteLine($"{kvp.Key,-15} {string.Join(", ", kvp.Value)}");
            }
        }

        public void DictionarySeed()
        {
            List<Door> b12345Doors = new List<Door>();
            b12345Doors.Add(Door.A7);
            Badge badge12345 = new Badge(12345, b12345Doors);
            _repo._badgeDictionary.Add(badge12345.BadgeID, b12345Doors);

            List<Door> b22345Doors = new List<Door>();
            b22345Doors.Add(Door.A1);
            b22345Doors.Add(Door.A4);
            b22345Doors.Add(Door.B1);
            b22345Doors.Add(Door.B2);
            Badge badge22345 = new Badge(22345, b22345Doors);
            _repo._badgeDictionary.Add(badge22345.BadgeID, b22345Doors);

            List<Door> b32345Doors = new List<Door>();
            b32345Doors.Add(Door.A4);
            b32345Doors.Add(Door.A5);
            Badge badge32345 = new Badge(32345, b32345Doors);
            _repo._badgeDictionary.Add(badge32345.BadgeID, b32345Doors);
        }

        public List<Door> WhileList()
        {
            List<Door> doorList = new List<Door>();
            bool addToList = true;
            while (addToList == true)                                            // Loop to add multiple doors to doorList
            {
                Console.WriteLine("List a door that it needs access to:\n" +
                    "Available doors are");
                foreach (var item in Enum.GetValues(typeof(Door)))              // List available doors in enum list
                {
                    Console.Write($" {item} ");
                }
                Console.WriteLine();
                string newDoor = Console.ReadLine().ToUpper();
                if (Enum.IsDefined(typeof(Door), newDoor))
                {
                    Door addedDoor = (Door)Enum.Parse(typeof(Door), newDoor);   // Parse string to enum
                    if (doorList.Contains(addedDoor))
                    {
                        Console.WriteLine("You've added that door to the list already.");
                    }
                    else
                    {
                        doorList.Add(addedDoor);
                        Console.WriteLine($"Successfully added {addedDoor}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid door number");
                }
                Console.WriteLine("Any other doors (Y/N?");
                string addMore = Console.ReadLine().ToUpper();
                if (addMore == "N" || addMore == "NO")
                {
                    addToList = false;
                }
            }
            return doorList;
        }
    }
}

