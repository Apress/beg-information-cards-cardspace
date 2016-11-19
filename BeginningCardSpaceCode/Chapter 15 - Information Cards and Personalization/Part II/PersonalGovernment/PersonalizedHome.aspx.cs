using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IdentityModel.Claims;
using Microsoft.IdentityModel.Samples;

public partial class PersonalizedHome : System.Web.UI.Page
{

    //TODO: Add your userID and password here.

    //if you don't have a userid and password, sign up here:
    //http://www.strikeiron.com/ProductDetail.aspx?p=257
    string userID = "username@hotmail.com ";
   string password = "password";


    protected void Page_Load(object sender, EventArgs e)
    {
        
        string xmlToken;
        xmlToken = Request.Params["xmlToken"];

        if (xmlToken == null || xmlToken == "")
        {
            Session["postalCode"] = Request.Params["tbZipCode"];
        }

        else
        {
             TokenHelper tokenHelper = new TokenHelper(xmlToken);
             RetrieveTokenClaims(tokenHelper.IdentityClaims);
        }
       
        string postalCode = (string)Session["postalCode"];
        if (!String.IsNullOrEmpty(postalCode))
        {
            
            ZipCodeInformation.RegisteredUser zcUser = new ZipCodeInformation.RegisteredUser();
            zcUser.UserID = userID;
            zcUser.Password = password;
            ZipCodeInformation.LicenseInfo zcLicenseIfo = new ZipCodeInformation.LicenseInfo();
            zcLicenseIfo.RegisteredUser = zcUser;

            ZipCodeInformation.SDPZipCodes zipCodeService = new ZipCodeInformation.SDPZipCodes();
            zipCodeService.LicenseInfoValue = new ZipCodeInformation.LicenseInfo();
            zipCodeService.LicenseInfoValue = zcLicenseIfo;
            ZipCodeInformation.ZipCodeOutput zipCodeInfo = zipCodeService.GetZipCode(postalCode);
           
            // Use the zipcode to retrieve city, state, and county. 
           // These will be used with the other services.
            
            Session["city"] = zipCodeInfo.ServiceResult.ZipCodes[0].PreferredCityName;
            Session["state"] = zipCodeInfo.ServiceResult.ZipCodes[0].State;
            Session["county"] = zipCodeInfo.ServiceResult.ZipCodes[0].County;

            pnlStateInfo.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(RenderStateInfo));
            pnlCityInfo.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(RenderCountyAndCityInfo));
            pnlCensusInformation.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(RenderCensusInfo));
            pnlSenatorInfo.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(RenderSenatorInfo));
            pnlHeader.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(RenderHeader));
        }
    }

    public void RenderHeader(HtmlTextWriter writer, System.Web.UI.Control control)
    {
        writer.Write("<h2>Your Government Information" + "</h2>");
        
    }
    public void RenderStateInfo(HtmlTextWriter writer, System.Web.UI.Control control)
    {
             
                StateInformation.SDPStateInformation stateService = new StateInformation.SDPStateInformation();
                StateInformation.StateInformationOutput stateInfo;
                StateInformation.LicenseInfo stateLicenseInfo = new StateInformation.LicenseInfo();
                StateInformation.RegisteredUser stateUser = new StateInformation.RegisteredUser();
                stateUser.UserID = userID;
                stateUser.Password = password;
                stateLicenseInfo.RegisteredUser = stateUser;   
                 stateService.LicenseInfoValue = stateLicenseInfo;
                 string state = (string)Session["state"];
                if (state.Length == 2)
                {
                    stateInfo = stateService.GetStateInformationForAbbreviation(state);
                }
                else
                {
                    stateInfo = stateService.GetStateInformation(state);
                }

                writer.WriteLine("<h1><b>" + stateInfo.ServiceResult.StateInformation[0].State + "</b></h1>");
                writer.WriteLine("<a href=\"http://" + stateInfo.ServiceResult.StateInformation[0].Website + "\">http://" + stateInfo.ServiceResult.StateInformation[0].Website + "</a>");                
                writer.WriteLine("<br>");
                writer.Write("<table>");
                writer.Write("<tr>");
                writer.Write("<td>Governor</td>");
                writer.Write("<td>" + stateInfo.ServiceResult.StateInformation[0].Governor + "</td>");
                writer.WriteLine("</tr>");

                writer.Write("<tr>");
                writer.Write("<td>State Capital</td>");
                writer.Write("<td>" + stateInfo.ServiceResult.StateInformation[0].Capital + "</td>");
                writer.WriteLine("</tr>");

                writer.Write("<tr>");
                writer.Write("<td>Population</td>");
                writer.Write("<td>" + stateInfo.ServiceResult.StateInformation[0].Population.ToString() + "</td>");
                writer.WriteLine("</tr>");

                writer.Write("<tr>");
                writer.Write("<td>Area</td>");
                writer.Write("<td>" + stateInfo.ServiceResult.StateInformation[0].Area.ToString() + "</td>");
                writer.WriteLine("</tr>");
                writer.Write("<tr>");
                writer.Write("<td>Time Zone</td>");
                writer.Write("<td>" + stateInfo.ServiceResult.StateInformation[0].Timezone + "</td>");
                writer.WriteLine("</tr>");
                writer.WriteLine("</table>");
                
                
            
}
    public void RenderSenatorInfo(HtmlTextWriter writer, System.Web.UI.Control control)
    {

    
             SenatorInformation.SDPUSSenator senatorService = new SenatorInformation.SDPUSSenator();
             SenatorInformation.RegisteredUser senatorUser = new SenatorInformation.RegisteredUser();
             senatorUser.UserID = userID;
             senatorUser.Password = password;
             SenatorInformation.LicenseInfo senatorLicenseInfo = new SenatorInformation.LicenseInfo();
             senatorLicenseInfo.RegisteredUser = senatorUser;
             senatorService.LicenseInfoValue = senatorLicenseInfo;
             string stateAbbreviation = (string)Session["state"];   
             SenatorInformation.USSenatorOutput senatorInfo = senatorService.GetUSSenators(stateAbbreviation);
             writer.WriteLine("<table>");
             writer.WriteLine("<tr>");
             foreach(SenatorInformation.USSenatorInfo senatorDetail in senatorInfo.ServiceResult.USSenators)
             {
                 writer.WriteLine("<td>");   
                 writer.WriteLine("<b>Senator " + senatorDetail.FirstName + " " + senatorDetail.LastName + "</b><br/>");
                 writer.WriteLine(senatorDetail.Party+ "<br/>");
                 writer.WriteLine("Term expires:" + senatorDetail.TermExpires + "<br/><br/>");   

                 writer.WriteLine("<table>");
                 writer.Write("<tr>");
                 writer.Write("<td>Website</td>");
                 writer.Write("<td><a href=\"http://" + senatorDetail.Website + "\">http://" + senatorDetail.Website + "</a></td>");
                 writer.WriteLine("</tr>");

                 writer.Write("<tr>");
                 writer.Write("<td>Address</td><td></td>");
                 writer.Write("</tr>"); 
                 writer.Write("<tr>");
                 writer.Write("<td><td>" + senatorDetail.Address + "<br/>");
                 writer.Write(senatorDetail.CityState + "<br/>");
                 writer.Write("</td>");
                 writer.WriteLine("</tr>");

                 writer.Write("<tr>");
                 writer.Write("<td>Phone</td>");
                 writer.Write("<td>" + senatorDetail.Phone + "</td>");
                 writer.WriteLine("</tr>");
                 writer.WriteLine("</table>");

                 writer.WriteLine("</td>");             
             }
             writer.WriteLine("</tr>");
             writer.WriteLine("</table>");
    }
    public void RenderCountyAndCityInfo(HtmlTextWriter writer, System.Web.UI.Control control)
    {

        CountyWebsites.SDPUSCountyWebSites countyService = new CountyWebsites.SDPUSCountyWebSites();
        CountyWebsites.RegisteredUser countyUser = new CountyWebsites.RegisteredUser();
        countyUser.UserID = userID;
        countyUser.Password = password;
        CountyWebsites.LicenseInfo countyLicenseInfo = new CountyWebsites.LicenseInfo();
        countyLicenseInfo.RegisteredUser = countyUser;
        string county = (string)Session["county"];
        string state = (string)Session["state"];
        countyService.LicenseInfoValue = countyLicenseInfo;

        CountyWebsites.USCountyWebsiteOutput countyInfo = countyService.GetUSCountyWebsite(county, state);
        if (countyInfo.ServiceResult.Websites.Length > 0)
        {
            writer.Write("<b>" + countyInfo.ServiceResult.Websites[0].County + " County</b></br>");
            writer.WriteLine("<a href=\"http://" + countyInfo.ServiceResult.Websites[0].Website + "\">http://" + countyInfo.ServiceResult.Websites[0].Website + "</a>");
            writer.WriteLine("<br/>");
            writer.WriteLine("<br/>");
        }
             CityWebSites.SDPUSCityWebsites cityService = new CityWebSites.SDPUSCityWebsites();
             CityWebSites.RegisteredUser cityUser = new CityWebSites.RegisteredUser();
             cityUser.UserID = userID;
             cityUser.Password = password;
             CityWebSites.LicenseInfo cityLicenseInfo = new CityWebSites.LicenseInfo();
             cityLicenseInfo.RegisteredUser = cityUser;
             cityService.LicenseInfoValue = cityLicenseInfo;

             string city = (string)Session["city"];
             
             CityWebSites.USCityWebsiteOutput cityInfo =  cityService.GetUSCityWebsite(city,state);

             if (cityInfo.ServiceResult.USCityWebsites.Length > 0)
             {
                 writer.Write("<b>" + city + "</b></br>");
                 writer.WriteLine("<a href=\"http://" + cityInfo.ServiceResult.USCityWebsites[0].Website + "\">http://" + cityInfo.ServiceResult.USCityWebsites[0].Website + "</a>");

             }
             
           
    }
    public void RenderCensusInfo(HtmlTextWriter writer, System.Web.UI.Control control)
    {
        string postalCode = (string)Session["postalCode"];

        CensusInformationForZipCode.SDPCensus censusService = new CensusInformationForZipCode.SDPCensus();
        CensusInformationForZipCode.RegisteredUser censusUser = new CensusInformationForZipCode.RegisteredUser();
        censusUser.UserID = userID;
        censusUser.Password = password;
        CensusInformationForZipCode.LicenseInfo censusLicenseInfo = new CensusInformationForZipCode.LicenseInfo();
        censusLicenseInfo.RegisteredUser = censusUser;
        censusService.LicenseInfoValue = censusLicenseInfo;
        CensusInformationForZipCode.CensusOutput censusInfo = censusService.GetCensusInfoForZipCode(postalCode);
        if (censusInfo.ServiceResult.CensusInfo.Length > 0)
        {
            writer.WriteLine("<h4>US Census Information for Zip Code " + (string)Session["PostalCode"] + "</h4>");
            writer.WriteLine("<table>");
            writer.Write("<tr>");
            writer.Write("<td>Total Population</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Total_pop.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Median Age</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Median_age.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Gender Composition</td>");
            writer.Write("<td >");
            writer.WriteLine("<table><tr>");
            writer.WriteLine("<td> Male:" + censusInfo.ServiceResult.CensusInfo[0].Male_pop + "<td>");
            writer.WriteLine("<td> Female:" + censusInfo.ServiceResult.CensusInfo[0].Female_pop + "<td>");
            writer.WriteLine("</tr></table>");
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Total Housing Units</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Total_housing_units.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Owner/Renter Composition</td>");
            writer.Write("<td >");
            writer.WriteLine("<table><tr>");
            writer.WriteLine("<td> Owner:" + censusInfo.ServiceResult.CensusInfo[0].Owner_occupied_housing_units + "<td>");
            writer.WriteLine("<td> Renter:" + censusInfo.ServiceResult.CensusInfo[0].Renter_occupied_housing_units + "<td>");
            writer.WriteLine("</tr></table>");
            writer.Write("</td>");
            writer.Write("</tr>");


            writer.Write("<tr>");
            writer.Write("<td>Rental vacancy percent</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Rental_vacancy_rate_percent.ToString() + "</td>");
            writer.Write("</tr>");




            writer.Write("<tr>");
            writer.Write("<td>Number of households</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Householder_pop.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Average household size</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Avg_household_size.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Number of family households</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Family_households.ToString() + "</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>Average family size</td>");
            writer.Write("<td>" + censusInfo.ServiceResult.CensusInfo[0].Avg_family_size.ToString() + "</td>");
            writer.Write("</tr>");



            writer.Write("</table>");
        }

    }
   
    private void RetrieveTokenClaims(ClaimSet claims)
    {
        foreach (Claim claim in claims)
        {

            switch (claim.ClaimType)
            {
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname":
                    Session["givenName"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname":
                    Session["surName"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier":
                    Session["ppid"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress":
                    Session["email"] = claim.Resource.ToString();
                    break;

                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality":
                    Session["city"] = claim.Resource.ToString();
                    break;

                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country":
                    Session["country"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode":
                    Session["postalCode"] = claim.Resource.ToString();
                    break;

                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince":
                    Session["state"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone":
                    Session["mobile"] = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress":
                    Session["street"] = claim.Resource.ToString();
                    break;

            }

        }
    }



}
