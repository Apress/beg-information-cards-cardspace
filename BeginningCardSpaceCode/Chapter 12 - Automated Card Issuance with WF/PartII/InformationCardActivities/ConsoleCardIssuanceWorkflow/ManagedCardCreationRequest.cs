using System;
using System.Collections.Generic;
using System.Text;
using BeginningCardSpace;

namespace ConsoleCardIssuanceWorkflow
{
	public class ManagedCardCreationRequest
	{
	
        private Dictionary<string, string> _claimValues;
        private string _templateName;
        private string _emailDeliveryAddressForCard;
        public string TemplateName
        {
            get { return _templateName; }
            set { _templateName = value; }
        
        }
        public string EmailDeliveryAddressForCard
        {
            get { return _emailDeliveryAddressForCard; }
            set { _emailDeliveryAddressForCard = value; }
        
        }
        public Dictionary<string, string> ClaimValues
        {
            get { return _claimValues; }
            set { _claimValues = value; }
        
        }

        public ManagedCardCreationRequest()
        {
            _claimValues = new Dictionary<string, string>();
        
        }

    }
}
