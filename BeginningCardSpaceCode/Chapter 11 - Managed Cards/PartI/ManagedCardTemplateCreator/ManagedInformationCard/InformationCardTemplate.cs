using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    [Serializable]
    public class InformationCardTemplate
    {
        private InformationCard _informationCard;
        private CertificateInfo _certificateInfo;

        public InformationCard InformationCardDefinition
        {
            get { return _informationCard; }
            set { _informationCard = value; }
        }

        public CertificateInfo SigningCertificateInfo
        {
            get { return _certificateInfo; }
            set { _certificateInfo = value; }
        }

        public InformationCardTemplate()
        {
            _informationCard = new InformationCard();
            _certificateInfo = new CertificateInfo();
        
        }


    }
}
