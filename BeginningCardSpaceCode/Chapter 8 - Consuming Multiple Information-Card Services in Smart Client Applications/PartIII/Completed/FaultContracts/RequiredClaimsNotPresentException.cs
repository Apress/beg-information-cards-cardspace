using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IdentityModel.Claims;

namespace FaultContracts
{
    [DataContract]
    public class RequiredClaimsNotPresentException
    {
        private List<string> _claimsNotPresent;

        public RequiredClaimsNotPresentException()
        {
            _claimsNotPresent = new List<string>();
        
        }

        [DataMember]
        public List<string> ClaimsNotPresent
        {
            get { return _claimsNotPresent; }
            set { _claimsNotPresent = value; }
        
        }
    
    
    
    }
}
