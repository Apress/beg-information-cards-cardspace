using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    [Serializable]
    public class TokenService
    {
        private EndpointReference _endpointReference;
        private UserCredential _userCredential;


        public TokenService()
        {
            _endpointReference = new EndpointReference();
            _userCredential = new UserCredential();
        }

        public EndpointReference EndpointReference
        {
            get { return _endpointReference; }
            set { _endpointReference = value; }
        
        }

        public UserCredential UserCredential
        {
            get { return _userCredential; }
            set { _userCredential = value; }
        }

    
    
    }
}
