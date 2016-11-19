using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class IdentityProviderDetails
    {
        private string _name;
        private string _address;
        private string _mexAddress;
        private string _policy;
        private string _certificatePath;
        private string _certificatePassword;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        
        }


        public string MexAddress
        {
            get { return _mexAddress; }
            set { _mexAddress = value; }
        }

        public string Policy
        {
            get { return _policy; }
            set { _policy = value; }
        
        }

        public string CertificatePath
        {
            get { return _certificatePath; }
            set { _certificatePath = value; }
        }

        public string CertificatePassword
        {
            get { return _certificatePassword; }
            set { _certificatePassword = value; }
        
        }

    
    }
}
