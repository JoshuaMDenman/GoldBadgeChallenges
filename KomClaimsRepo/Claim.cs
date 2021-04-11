using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomClaimsRepo
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimId { get; set; }
        public ClaimType Type { get; set; }
        public string Desc { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public bool Handled { get; set; }

        public Claim() { }

        public Claim(int claimId, ClaimType type, string desc, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid, bool handled)
        {
            ClaimId = claimId;
            Type = type;
            Desc = desc;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            Handled = handled;


        }
    }
}
