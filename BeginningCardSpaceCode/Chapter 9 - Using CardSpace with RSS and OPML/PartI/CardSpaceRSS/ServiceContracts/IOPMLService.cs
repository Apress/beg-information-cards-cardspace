using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Rss;

namespace ServiceContracts
{
    [ServiceContract]
    public interface IOPMLService
    {
        [OperationContract]
        Rss.OPML GetOPML();
    }
}
