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
            try
            {
                var resourcePath = HttpRuntime.AppDomainAppPath + "/Resources/ClaimData.json";

                var claims = GetClaims();
                claims.Add(claim);
                var result = JsonConvert.SerializeObject(claims);
                System.IO.File.WriteAllText(resourcePath, result);
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }
    }
}