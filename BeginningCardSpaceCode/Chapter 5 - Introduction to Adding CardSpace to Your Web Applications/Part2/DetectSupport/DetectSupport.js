//Use this routine to populate Divs via Javascript

function populateDiv(id, text)
{
if (document.getElementById(id))
{
var element = document.getElementById(id);
element.innerHTML = text;
}

}

//This function examines the user agent and determines if Internet Explorer is running
function RunningInternetExplorer()
{
    var runningIE = (navigator.userAgent.toUpperCase().indexOf("MSIE") >= 0);            
    return (runningIE); 
}

//This determines the version of IE
function GetIEVersion()
{
    if(RunningInternetExplorer())
    {
        if (new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})").exec(navigator.userAgent) != null)
            return parseFloat( RegExp.$1 );
    }
    else
    {
        return 0; 
    }
}

function IsCardSpaceSupported()
{
    var supported = false;
    
    try
    {
        var informationCard = document.getElementById(informationCard);
        
        if ( RunningInternetExplorer() )
        {
            //This is running a version of Internet Explorer
                 
            if ( GetIEVersion() >= 7 )
            //This is running a version where CardSpace/Information Cards could be supported 
            {
                if ( informationCard.isInstalled )
                {
                   //Information card support is available 
                    supported = true; 
                }
            }
        }
        else 
        {
  
            if ( navigator.mimeTypes && navigator.mimeTypes.length )
            {
                var ic = navigator.mimeTypes['application/x-informationcard'];
                
                if ( ic && ic.enabledPlugin ) //Installed and enabled
                    supported = true;
            }
        }
    }
    catch (e)
    {
        return false;
    }
    
    return supported;
}