using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIClaims.Models
{
    public class Claim
    {
        public int ClaimNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime ClaimedDate { get; set; }
        public float ClaimAmount { get; set; }
        public int PolicyNo { get; set;}
        public string Gender { get; set; }

    }
}