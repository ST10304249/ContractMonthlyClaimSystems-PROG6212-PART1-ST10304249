using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract_Monthly_Claim.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required(ErrorMessage = "Lecturer ID is required.")]
        public string LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDate { get; set; }
        public decimal RatePerHour { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateOfClaim { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // property to store the file path or file name
        public string SupportingDocumentPath { get; set; }

        //  List of supporting documents related to this claim
        public List<SupportingDocument> SupportingDocuments { get; set; }
    }
    public enum ClaimStatus
    {
        Submitted,
        PendingReview,
        ApprovedByCoordinator,
        RejectedByCoordinator,
        ApprovedByManager,
        RejectedByManager
    }

   

    public class SupportingDocument
    {
        public int DocumentId { get; set; }
        public int ClaimId { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentContent { get; set; }
    }
}
