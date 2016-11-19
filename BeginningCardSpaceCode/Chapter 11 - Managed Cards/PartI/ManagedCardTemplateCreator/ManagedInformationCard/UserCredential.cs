using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    [Serializable]
    public enum CredentialType
    {
        Kerberos=0,
        SelfIssued =1,
        SmartCard=2,
        UsernameAndPassword=3
    
    }
    
    [Serializable]
    public class UserCredential
    {
        private string _displayCredentialHint;
        private CredentialType _userCredentialType;
        private object _value;

        public string DisplayCredentialHint
        {
            get {return _displayCredentialHint;}
            set {_displayCredentialHint = value;}
        }
    
    
        public CredentialType UserCredentialType
        {
            get {return _userCredentialType;}
            set {_userCredentialType = value;}
        }


        public object Value
        {
            get {return _value;}
            set {_value = value;}
        
        }


    }
}
