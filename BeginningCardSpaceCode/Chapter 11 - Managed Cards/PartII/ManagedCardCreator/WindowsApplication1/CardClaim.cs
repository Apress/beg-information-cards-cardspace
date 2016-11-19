using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class CardClaim
    {
        private string _uri;
        private string _displayTag;
        private string _description;
        private string _value;

        public string Uri
        {
            get {return _uri;}
            set {_uri = value;}
        
        }
    
        public string DisplayTag
        {
            get {return _displayTag;}
            set { _displayTag = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Value
        {
            get { return _value; }
            set { _value = value; }
        
        }
        
        
        public override string ToString()
        {
            return DisplayTag;
        }


        public CardClaim()
        { }

        public CardClaim(string uri, string displayTag, string description)
        {
            _uri = uri;
            _displayTag = displayTag;
            _description = description;
        
        }

        public CardClaim(string uri, string displayTag, string description, string value)
        {
            _uri = uri;
            _displayTag = displayTag;
            _description = description;
            _value = value;
        }
    
    
    }
}
