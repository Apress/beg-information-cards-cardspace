using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{

    
    public class InformationCard
    {
        private InformationCardReference _informationCardReference;
        private string _cardName;
        private CardImage _cardImage;
        private string _issuer;
        private DateTime _timeIssued;
        private DateTime _timeExpires;
        private List<TokenService> _tokenServiceList;
        private List<CardClaim> _supportedClaimType;
        private string _privacyNotice;
        private bool _requireRPIdentification;
        private List<TokenType> _acceptedTokenTypes;
        private string _issuerName;

        public string IssuerName
        {
            get { return _issuerName; }
            set { _issuerName = value; }
        }

        public InformationCard()
        {
            _tokenServiceList = new List<TokenService>();
            _supportedClaimType = new List<CardClaim>();
            _acceptedTokenTypes = new List<TokenType>();
            _informationCardReference = new InformationCardReference();
            _cardImage = new CardImage();
        
        
        }

        public InformationCardReference CardReference
        {
            get { return _informationCardReference; }
            set { _informationCardReference = value; }
        }

        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; }
        }


        public CardImage CardImage
        {
            get { return _cardImage; }
            set { _cardImage = value; }
        
        }

        public string Issuer
        {
            get { return _issuer; }
            set { _issuer = value; }
        }

        public DateTime TimeIssued
        {
            get { return _timeIssued; }
            set { _timeIssued = value; }
        
        }

        public DateTime TimeExpires
        {
            get { return _timeExpires; }
            set { _timeExpires = value; }
        }

        public List<TokenService> TokenServiceList
        {
            get { return _tokenServiceList; }
            set { _tokenServiceList = value; }
        
        }

        public List<CardClaim> SupportedClaimTypeList
        {
            get { return _supportedClaimType; }
            set { _supportedClaimType = value; }
        
        }

        public string PrivacyNotice
        {
            get { return _privacyNotice; }
            set { _privacyNotice = value; }
        
        }


        public bool RequireRPIdentification
        {

            get { return _requireRPIdentification; }
            set { _requireRPIdentification = value;}
            
        }


        public List<TokenType> AcceptedTokenTypes
        {
            get { return _acceptedTokenTypes; }
            set { _acceptedTokenTypes = value; }
        
        
        }
    
    }
}
