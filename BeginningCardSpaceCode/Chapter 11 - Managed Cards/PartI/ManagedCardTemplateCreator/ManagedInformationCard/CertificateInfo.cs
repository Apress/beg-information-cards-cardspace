using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    [Serializable]
    public class CertificateInfo
    {
        private string _store;
        private string _location;
        private string _commonName;


        public string Store
        {
            get { return _store; }
            set { _store = value; }
        
        }

        public string Location
        {
            get { return _location; }
            set {_location = value;}
        
        }


        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        
        }


    }
}
