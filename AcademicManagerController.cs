using Microsoft.AspNetCore.Mvc;
using Contract_Monthly_Claim.Models;
using Contract_Monthly_Claim.Services;
using System.Linq;

namespace Contract_Monthly_Claim.Controllers
{
    public class AcademicManagerController : Controller
    {
        public IActionResult Dashboard()
        {
            // Get claims approved by Programme Coordinator and awaiting Academic Manager review
            var claimsAwaitingReview = ClaimService.GetClaimsByStatus("ApprovedByCoordinator");
            return View(claimsAwaitingReview);
        }


        public IActionResult ReviewClaim(int id)
        {
            var claim = ClaimService.GetAllClaims()
                .FirstOrDefault(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        [HttpPost]
        public IActionResult ApproveClaim(int id)
        {
            var claim = ClaimService.GetAllClaims()
                .FirstOrDefault(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "ApprovedByManager";
            ClaimService.Update(claim);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult RejectClaim(int id, string reason)
        {
            var claim = ClaimService.GetAllClaims()
                .FirstOrDefault(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "RejectedByManager";
            claim.Description = reason; // Store rejection reason
            ClaimService.Update(claim);
            return RedirectToAction("Dashboard");
        }
    }
}
