using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Services;
using ServiceContracts;
using Rss;

namespace CardSpaceRSS
{
    class Program
    {
        static void Main(string[] args)
        {



            ServiceHost shOPML = new ServiceHost(typeof(Services.OPMLService), new Uri("http://localhost:1972/BeginningCardSpace/OPML"));
            shOPML.Open();
            Console.WriteLine("OPML Service Is Now Online");
            Console.WriteLine("---------------------------------------");


            ServiceHost shRSS = new ServiceHost(typeof(Services.RSSService), new Uri("http://localhost:1972/BeginningCardSpace"));
            shRSS.Open();
            Console.WriteLine("RSS Service Is Now Online");
            Console.WriteLine("---------------------------------------");
 
            Console.WriteLine("To Stop Service, Press Enter.");
            Console.ReadLine();
            shRSS.Close();
            shOPML.Close();
            
        }
    
    
    }
}
