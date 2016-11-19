using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class InformationCardReference
    {
        private string _cardID ="";
        private int _cardVersion =1;

        public string CardID
        {
            get { return _cardID; }
            set { _cardID = value; }
        }

        public int CardVersion
        {
            get { return _cardVersion; }
            set { _cardVersion = value; }
        
        }

    }
}
