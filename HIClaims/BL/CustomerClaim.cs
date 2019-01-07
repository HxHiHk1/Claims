using HIClaims.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Reflection;
using Newtonsoft.Json;

namespace HIClaims.BL
{
    public class CustomerClaim
    {
        public List<Claim> GetClaims()
        {
            string result = string.Empty;
            var claims = new List<Claim>();
            
            var resourcePath = HttpRuntime.AppDomainAppPath+ "/bin/Resources/ClaimData.json";
            using (StreamReader reader = new StreamReader(resourcePath))
            {
                result = reader.ReadToEnd();
            }
            claims = JsonConvert.DeserializeObject<List<Claim>>(result);
            return claims;
        }

        public bool SaveClaims( Claim claim)
        {
            bool returnValue = false;
            try
            {
                if (claim.ClaimedDate > DateTime.Now)
                    throw new Exception("Claim can not be future date");
                
                var resourcePath = HttpRuntime.AppDomainAppPath + "/bin/Resources/ClaimData.json";

                var claims = GetClaims();
                claims.Add(claim);
                var result = JsonConvert.SerializeObject(claims);
                System.IO.File.WriteAllText(resourcePath, result);
                returnValue = true;
            }catch(Exception e)
            {
                returnValue = false;
                throw;
            }
            return returnValue;

        }

    }
}