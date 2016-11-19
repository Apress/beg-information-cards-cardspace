using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class ManagedCard
    {
        private List<CardClaim> _containedClaims;
        private IdentityProviderDetails _providerDetails;
        private string _ID;
        private string _name;
        private string _picturePath;
        private int _version;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        
        }


        public string PicturePath
        {
            get { return _picturePath; }
            set { _picturePath = value; }
        
        }

        public int Version
        {
            get { return _version; }
            set { _version = value; }
        
        }

        public IdentityProviderDetails ProviderDetails
        {
            get { return _providerDetails; }
            set { _providerDetails = value; }
        
        }


        public List<CardClaim> ContainsClaims
        {
            get { return _containedClaims; }
            set { _containedClaims = value; }
            
        }


    }
}
