using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class TokenType
    {
        private string _uri;
        private string _name;
        private bool _accepted;

        public TokenType()
        { }

        public TokenType(string uri, string name, bool accepted)
        {
            _uri = uri;
            _name = name;
            _accepted = accepted;
        }

        public string Uri
        {
            get { return _uri; }
            set { _uri = value; }
        
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        
        }

        public bool Accepted
        {
            get { return _accepted; }
            set { _accepted = value; }
        
        }

    }
}
