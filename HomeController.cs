using Contract_Monthly_Claim.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contract_Monthly_Claim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Static list to store claims in memory
        private static List<Claim> claims = new List<Claim>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Claim()
        {
            return View();
        }


        public IActionResult Status()
        {
            return View();
        }
        public IActionResult Verify()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Claim(Models.Claim model)
        {

            if (ModelState.IsValid)
            {
                // Generate a unique ClaimNumber
                model.ClaimNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // Store the claim in the static list
                model.DateOfClaim = DateTime.Now;
                model.Status = "Pending";
                claims.Add(model);

                // Redirect to a confirmation page
                return RedirectToAction("Verify", new { claimNumber = model.ClaimNumber });
            }

            return View(model);
        }

        [HttpGet]


        [HttpGet]
        public IActionResult Track()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Track(string claimNumber)
        {
            var claim = claims.FirstOrDefault(c => c.ClaimNumber == claimNumber);
            if (claim == null)
            {
                ViewBag.Message = "Claim not found.";
                return View();
            }

            return View("Status", claim);
        }

        // Simulated project manager view for processing claims
        public IActionResult Manage()
        {
            // Only return claims with a "Pending" status
            var pendingClaims = claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult UpdateClaimStatus(int claimId, string status)
        {
            // Find the claim using the ClaimId
            var claim = claims.FirstOrDefault(c => c.ClaimId == claimId);

            // Check if the claim exists and the status is valid
            if (claim != null && (status == "Approved" || status == "Declined"))
            {
                claim.Status = status;
            }

            // Redirect to the "Manage" view after updating the status
            return RedirectToAction("Manage");
        }
    }
    

}
