using KomClaimsRepo;
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
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Claims Department Management\n\n" +
                    "Select an option:\n\n" +
                    "1. View all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
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
                            "Komodo Claims Department Management\n" +
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
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
        }

        public void NextClaim()
        {
            List<Claim> List = _repo.GetAllClaims();
            foreach (Claim claim in List)
            {
                if (claim.Handled == false)
                {

                    Console.Clear();
                    Console.Write("Here are the details for the next claim to be handled:\n\n" +
                        $"ClaimID: {claim.ClaimId}\n\n" +
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

        public void ViewClaims()
        {
            Console.Clear();
            List<Claim> allClaims = _repo.GetAllClaims();

            Console.WriteLine($"\n{"ClaimId",-10} {"Type",-10} {"Description",-50} {"Amount",-10} {"DateOfIncident",-15} {"DateOfClaim",-15}\n");
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"{claim.ClaimId,-10} {claim.Type,-10} {claim.Desc,-50} ${claim.ClaimAmount,-10} {claim.DateOfIncident.ToShortDateString(),-15} {claim.DateOfClaim.ToShortDateString(),-15}");
            }
        }
        public void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.Write("Enter Claim Id: ");
            int claimId = Convert.ToInt32(Console.ReadLine());
            newClaim.ClaimId = claimId;

            Console.Write("Enter Claim Type(Car, Home, Theft): ");
            string claimType = Console.ReadLine();
            switch (claimType.ToLower())
            {
                case "car":
                    newClaim.Type = ClaimType.Car;
                    break;
                case "home":
                    newClaim.Type = ClaimType.Home;
                    break;
                case "theft":
                    newClaim.Type = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Enter valid claim type of Car, Home, or Theft. Learn to read dummy.");
                    break;
            }

            Console.Write("Describe the claim: ");
            string claimDesc = Console.ReadLine();
            newClaim.Desc = claimDesc;

            Console.Write("Enter claim damage amount(DO NOT ENTER $): ");
            string claimAmount = Console.ReadLine();
            if (claimAmount.Contains("$"))
            {
                claimAmount = claimAmount.Replace("$", string.Empty);
                newClaim.ClaimAmount = Convert.ToDouble(claimAmount);
            }
            else
            {
                newClaim.ClaimAmount = Convert.ToDouble(claimAmount);
            }

            Console.Write("Enter date of incident(yyyy/mm/dd): ");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Set claim date to today(Yes or No): ");
            string claimToday = Console.ReadLine();
            if (claimToday.ToLower() == "no")
            {
                Console.Write("Enter date of claim(yyyy/mm/dd): ");
                newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            }
            else if (claimToday.ToLower() == "yes")
            {
                newClaim.DateOfClaim = DateTime.Today;
            }
            else
            {
                Console.WriteLine("Please enter Yes or No");
            }

            TimeSpan sinceIncident = newClaim.DateOfClaim - newClaim.DateOfIncident;
            if (sinceIncident.Days > 30)
            {
                Console.Write($"{sinceIncident} Days have passed since incident. This claim is not valid.");
                newClaim.IsValid = false;
            }
            else
            {
                Console.WriteLine($"{sinceIncident} days have passed since incident. Is this a vaild claim(Yes or No): ");
                string claimValid = Console.ReadLine();
                if (claimValid.ToLower() == "no")
                {
                    newClaim.IsValid = false;
                }
                else if (claimValid.ToLower() == "yes")
                {
                    newClaim.IsValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter Yes or No");
                }
                newClaim.Handled = false;
                _repo.AddClaim(newClaim);

            }
        }
    }
}
