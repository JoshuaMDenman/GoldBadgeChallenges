using ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    public class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();
        public void Run()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("KOMODO CLAIMS DEPARTMENT MANAGEMENT\n\n" +
                    "Select an option:\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter an new claim\n" +
                    "0. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "0":
                        Console.WriteLine("Thank you for using\n" +
                            "KOMODO CLAIMS DEPARTMENT MANAGEMENT\n" +
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
        public void ViewClaims()
        {
            Console.Clear();
            List<Claim> allClaims = _repo.GetAllClaims();

            Console.WriteLine($"\n{"ClaimID",-10} {"Type",-10} {"Description",-50} {"Amount",-10} {"DateOfIncident",-15} {"DateOfClaim", -15} {"IsValid", -10} {"Handled"}\n");
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"{claim.ClaimID, -10} {claim.Type, -10} {claim.Desc, -50} ${claim.ClaimAmount, -10} {claim.DateOfIncident.ToShortDateString(), -15} {claim.DateOfClaim.ToShortDateString(), -15} {claim.IsValid, -10} {claim.Handled}");
            }

        }

        public void NextClaim()
        {
            List <Claim> List = _repo.GetAllClaims();
            foreach (Claim claim in List)
            {
                if(claim.Handled == false)
                {
                    Console.Clear();
                    Console.Write("Here are the details for the next claim to be handled:\n\n" +
                        $"ClaimID: {claim.ClaimID}\n\n" +
                        $"Type: {claim.Type}\n\n" +
                        $"Description: {claim.Desc}\n\n" +
                        $"Amount: ${claim.ClaimAmount}\n\n" +
                        $"DateOfIncident: {claim.DateOfIncident}\n\n" +
                        $"DateOfClaim: {claim.DateOfClaim}\n\n" +
                        $"IsValid: {claim.IsValid}\n\n\n" +
                        $"Do you want to deal with this claim now (YES / NO)?");
                    string handleNow = Console.ReadLine();
                    if (handleNow.ToUpper() == "YES")
                    {
                        claim.Handled = true;
                        RunMenu();
                    }
                }
            }
            Console.WriteLine("Queue is clear. No more claims to be handled.");
                        
        }
        public void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            List<Claim> all = _repo.GetAllClaims();
            newClaim.ClaimID = all.Count + 1; // new Claim ID automatically set to next number
            
            Console.Write("Enter Claim Type (Car / Home / Theft):");
            string input = Console.ReadLine();
            if(input.ToLower() == "car")
            {
                newClaim.Type = ClaimType.Car;
            }
            else if(input.ToLower() == "home")
            {
                newClaim.Type = ClaimType.Home;
            }
            else if (input.ToLower() == "theft")
            {
                newClaim.Type = ClaimType.Theft;
            }
            else
            {
                Console.WriteLine("Not a valid claim type.");
            }
            
            Console.Write("Describe the claim:");
            newClaim.Desc = Console.ReadLine();

            Console.Write("Enter amount of damage in $:");
            string damage = Console.ReadLine();
            if (damage.Contains("$"))
            {
                newClaim.ClaimAmount = Convert.ToDouble(damage.Replace("$", ""));
            }
            else
            {
                newClaim.ClaimAmount = Convert.ToDouble(damage);
            }
            Console.Write("Enter date of incident (YYYY/MM/DD):");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Set Claim Date to today (YES / NO):");
            string toToday = Console.ReadLine();
            if (toToday.ToUpper() == "NO")
            {
                Console.Write("Enter date of claim (YYYY/MM/DD):");
                newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            }
            else
            {
                newClaim.DateOfClaim = DateTime.Today;
            }

            Console.Write("Is claim valid (YES / NO):");
            string validClaim = Console.ReadLine();
            if (validClaim.ToUpper() == "NO")
            {
                newClaim.IsValid = false;
            }
            else
            {
                newClaim.IsValid = true;
            }

            newClaim.Handled = false;
            _repo.AddClaim(newClaim);
        }

        public void Seed()
        {
            Claim Andrew = new Claim(1, ClaimType.Car, "Ran over student at Eleven Fifty Academy", 15000.00, new DateTime(2021, 02, 14), new DateTime(2021, 02, 15), true, true);
            Claim Seth = new Claim(2, ClaimType.Theft, "Lost his marbles", 1000.00, new DateTime(2021, 02, 14), new DateTime(2021, 02, 15), true, false);
            Claim Gordon = new Claim(3, ClaimType.Home, "Hail damage", 4500.00, new DateTime(2021, 02, 15), new DateTime(2021, 02, 16), false, false);
            _repo.AddClaim(Andrew);
            _repo.AddClaim(Seth);
            _repo.AddClaim(Gordon);
        }
    }
}
