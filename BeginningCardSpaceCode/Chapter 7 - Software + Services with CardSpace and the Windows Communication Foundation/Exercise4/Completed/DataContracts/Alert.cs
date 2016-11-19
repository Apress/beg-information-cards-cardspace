using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class Alert
    {
        private string _title;
        private string _alertText;
        private string _alertHTML;

        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        
        }

        [DataMember]
        public string AlertText
        {
            get { return _alertText; }
            set { _alertText = value; }
        
        }

        [DataMember]
        public string AlertHTML
        {
            get { return _alertHTML; }
            set { _alertHTML = value; }

        }

    }
}
