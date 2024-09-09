using Microsoft.AspNetCore.Mvc;
using Contract_Monthly_Claim.Models;
using Contract_Monthly_Claim.Services;
using System.Collections.Generic;

namespace Contract_Monthly_Claim.Controllers
{
    public class ProgrammeCoordinatorController : Controller
    {
        public IActionResult Dashboard()
        {
            // Get claims awaiting review by Programme Coordinator
            var claimsAwaitingReview = ClaimService.GetClaimsByStatus("Pending");
            return View(claimsAwaitingReview);
        }

        public IActionResult SubmitClaim(Claim claim)
        {
            claim.Status = "Pending"; // Ensure this status is set
            ClaimService.Save(claim);
            return RedirectToAction("Index");
        }

        public IActionResult ReviewClaim(int id)
        {
            var claim = ClaimService.FindClaim(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        [HttpPost]
        public IActionResult ApproveClaim(int id)
        {
            var claim = ClaimService.FindClaim(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "ApprovedByCoordinator";
            ClaimService.Update(claim);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult RejectClaim(int id, string reason)
        {
            var claim = ClaimService.FindClaim(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "RejectedByCoordinator";
            claim.Description = reason; // Store rejection reason
            ClaimService.Update(claim);
            return RedirectToAction("Dashboard");
        }
    }
}
