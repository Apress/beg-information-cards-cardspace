using System;
using System.Collections.Generic;
using System.Text;
using Rss;
using System.ServiceModel;

namespace ServiceContracts
{
    [ServiceContract]
    public interface IRSSService
    {
        [OperationContract]
        Rss.RssFeed GetFeed();        
    }
}
