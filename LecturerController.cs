using Microsoft.AspNetCore.Mvc;
using Contract_Monthly_Claim.Models;
using Contract_Monthly_Claim.Services;
using System.Collections.Generic;

namespace Contract_Monthly_Claim.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult SubmitClaim()
        {
            return View(new Claim());
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim model, List<IFormFile> supportingDocuments)
        {
            if (ModelState.IsValid)
            {
                model.Status = "Pending";

                // Handle file uploads
                if (supportingDocuments != null && supportingDocuments.Count > 0)
                {
                    model.SupportingDocuments = new List<SupportingDocument>();
                    foreach (var file in supportingDocuments)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            file.CopyTo(memoryStream);
                            model.SupportingDocuments.Add(new SupportingDocument
                            {
                                DocumentId = ClaimService.GetAllClaims().Count + 1,
                                ClaimId = model.ClaimId,
                                DocumentName = file.FileName,
                                DocumentContent = memoryStream.ToArray()
                            });
                        }
                    }
                }

                ClaimService.Save(model);

                TempData["SuccessMessage"] = "Claim submitted successfully.";
                return RedirectToAction("SubmitClaim");
            }
            return View(model);
        }
    }
}
