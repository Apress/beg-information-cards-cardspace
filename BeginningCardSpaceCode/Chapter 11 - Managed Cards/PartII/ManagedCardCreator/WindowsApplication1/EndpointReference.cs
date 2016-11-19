using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class EndpointReference
    {
        private string _address;
        private string _mex;
        private string _identity;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Mex
        {
            get { return _mex; }
            set { _mex = value; }
        }

        public string Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }
    
    }
}
