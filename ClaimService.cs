using Contract_Monthly_Claim.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contract_Monthly_Claim.Services
{
    public class ClaimService
    {
        // A static list that holds all the claims in memory (mocking a database)
        private static List<Claim> Claims = new List<Claim>();


        // Retrieves all claims from the list.
        public static List<Claim> GetAllClaims()
        {
            return Claims;
        }


        // Method to get claims by status
        public static List<Claim> GetClaimsByStatus(string status)
        {
            return Claims.Where(c => c.Status == status).ToList();
        }

        // Save a new claim
        public static void Save(Claim claim)
        {
            claim.ClaimId = Claims.Count + 1;
            Claims.Add(claim);
            Console.WriteLine($"Claim added: {claim.ClaimId}, Status: {claim.Status}"); // Debugging line
        }



        // Find a claim by its ID
        public static Claim FindClaim(int claimId)
        {
            return Claims.FirstOrDefault(c => c.ClaimId == claimId);
        }

        // Retrieves claims filtered by a specific status (e.g., "Pending", "Approved").
        public static List<Claim> GetPendingClaims()
        {
            return Claims.Where(c => c.Status == "Pending").ToList();
        }

        // Updates an existing claim with new values.
        public static void Update(Claim updatedClaim)
        {
            var existingClaim = FindClaim(updatedClaim.ClaimId); // Look for the claim to update.
            if (existingClaim != null)
            {
                // Update fields of the existing claim with new data
                existingClaim.Status = updatedClaim.Status;
                existingClaim.ClaimAmount = updatedClaim.ClaimAmount;
                existingClaim.RatePerHour = updatedClaim.RatePerHour;
                existingClaim.SupportingDocumentPath = updatedClaim.SupportingDocumentPath;
                
            }
        }
    }
}
