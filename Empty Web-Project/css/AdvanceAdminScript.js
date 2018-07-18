// JScript File


if(typeof(Sys)!=='undefined')Sys.Application.add_init(AppInit);

function AppInit(sender) {
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
}
function sstchur_SmartScroller_GetCoords()   {}
  
function sstchur_SmartScroller_Scroll()
   {
   }

function gotoContentTop()
{
    document.getElementById('innerContentHolderArea').scrollTop = 0;
}
   
function resetScrollCordinate()
{
    document.getElementById('scrollBarLeft').value = 0;
    document.getElementById('scrollBarTop').value = 0; 
}   
   
function webappPrepare()
{
    history.go(+1);
    resetScrollCordinate();
    getscrollCordinate();
    alertSize();    
}
   
function webappEndresponse()
{
    alertSize();
    getscrollCordinate();
    resetScrollCordinate();
}
   
function setscrollCordinate()
{    
    var scrollX, scrollY;
    var scrollX1, scrollY1;
    //scrollX = document.getElementById('innerContentHolderArea').scrollLeft;
    //scrollY = document.getElementById('innerContentHolderArea').scrollTop;
    
    document.getElementById('scrollBarLeft').value = scrollX;
    document.getElementById('scrollBarTop').value = scrollY;
}

function getscrollCordinate()
{
    var x = document.getElementById('scrollBarLeft').value;
    var y = document.getElementById('scrollBarTop').value;
    
    //document.getElementById('sdmenu').scrollTop = y;
}
   
  window.onload = webappPrepare;
  window.onresize = webappPrepare; 


function BeginRequestHandler(sender, args)
{                     
}
function EndRequestHandler(sender, args)
{
    webappEndresponse();
}

function resizeMenu(lside,id)
{
    var attr = lside + ',*';
    var frameSet = parent.document.getElementById(id);
    frameSet.setAttribute('cols',attr);
}

function resizeMenuMasterPage(lsize,id)
{
    var leftMenu = parent.document.getElementById(id);
    leftMenu.style.width = lsize;
}

function ShowAccording ( showImage, hideImage, subMenuid)
{
    var showImageMenu = document.getElementById( showImage );
    var hideImageMenu = document.getElementById( hideImage );
    var subMenu = document.getElementById( subMenuid );

    showImageMenu.style.display = "";
    hideImageMenu.style.display = "none";  
    subMenu.style.display = '';
}

function showHideImage ( showImage, hideImage, subMenuid )
{
    var showImageMenu = document.getElementById( showImage );
    var hideImageMenu = document.getElementById( hideImage );
    var subMenu = document.getElementById( subMenuid );
    if (showImageMenu.style.display == 'block' || showImageMenu.style.display == '')
    {
        showImageMenu.style.display = "none";
        hideImageMenu.style.display = "";
        subMenu.style.display = 'none';
    }
    else
    {
        showImageMenu.style.display = "";
        hideImageMenu.style.display = "none";  
        subMenu.style.display = '';  
    }
}

function showMenu(){
document.getElementById('MenuShow').style.display = "";
document.getElementById('MenuShowA').style.display = "";
document.getElementById('MenuHide').style.display = "none";
document.getElementById('MenuHideA').style.display = "none";
document.getElementById('innerMenu').style.width = "93%";
document.getElementById('adminBodyMenu').style.width = "12%";
var contentWidth = parseInt( document.getElementById('adminBodyContent').style.width );
document.getElementById('adminBodyContent').style.width = ( 87 ) + "%";}

function hideMenu(){
document.getElementById('MenuShow').style.display = "none";
document.getElementById('MenuShowA').style.display = "none";
document.getElementById('MenuHide').style.display = "";
document.getElementById('MenuHideA').style.display = "";
document.getElementById('innerMenu').style.width = "0px";
document.getElementById('adminBodyMenu').style.width = "18px";
 var contentWidth = parseInt( document.getElementById('adminBodyContent').style.width ); // removes the "px" at the end
document.getElementById('adminBodyContent').style.width = ( 100 ) + "%";}

  
function alertSize() {
    var myWidth = 0, myHeight = 0;
    if( typeof( window.innerWidth ) == 'number' ) {
        //Non-IE
        myWidth = window.innerWidth;
        myHeight = window.innerHeight;
    } else if( document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) {
        //IE 6+ in 'standards compliant mode'
        myWidth = document.documentElement.clientWidth;
        myHeight = document.documentElement.clientHeight;
    } else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) {
        //IE 4 compatible
        myWidth = document.body.clientWidth;
        myHeight = document.body.clientHeight;
    }

    var borderTop = 37, borderBottom = 5;
    var borderLeft = 5, borderRight = 5;
  
    var shadowLeft = 3, shadowRight = 3;
    var shadowTop = 3, shadowBottom = 3;
  
    var marginInnerTop = 8; marginInnerBottom = 0;
    var marginInnerLeft = 8; marginInnerRight =8;
  
    var InnerBorderTop = 1; InnerBorderBottom = 1;
    var InnerBorderLeft =1; InnerborderRight = 1;
  
    var headerHeight = 75;
  
    var innerContentHeaderHeight = 21;
    var innerContentHolderAreaHeight = 0;
  
    var menuMinWidth = 18; menuMaxWidth = 10;
  
//    document.getElementById('AdminArea').style.width = ( myWidth-borderLeft-borderRight ) + "px";
//    document.getElementById('AdminArea').style.height = ( myHeight-borderTop-borderBottom ) + "px";
//        
   // document.getElementById('adminMainBorder').style.width = ( myWidth-borderLeft-shadowLeft-shadowRight-borderRight ) + "px";
  //  document.getElementById('adminMainBorder').style.height = ( myHeight-borderTop-shadowTop-shadowBottom-borderBottom ) + "px";

    //document.getElementById('adminMainInnerBorder').style.width = ( myWidth-borderLeft-shadowLeft-shadowRight-borderRight-marginInnerLeft-marginInnerRight-InnerBorderLeft-InnerborderRight ) + "px";
    //document.getElementById('adminMainInnerBorder').style.height = ( myHeight-borderTop-shadowTop-shadowBottom-borderBottom-marginInnerTop-marginInnerBottom-InnerBorderTop-InnerBorderBottom ) + "px";  
        
    //document.getElementById('ShadowTopCenter').style.width = ( myWidth-borderLeft-shadowLeft-shadowRight-borderRight ) + "px";        
   // document.getElementById('ShadowLeft').style.height = ( myHeight-borderTop-shadowTop-shadowBottom-borderBottom ) + "px";
    //document.getElementById('ShadowRight').style.height = ( myHeight-borderTop-shadowTop-shadowBottom-borderBottom ) + "px";
    //document.getElementById('ShadowBottomCenter').style.width = (myWidth-borderLeft-shadowLeft-shadowRight-borderRight) + "px";      
            
    //Content Area.   adminBody, adminBodyMenu, adminBodyContent   
    document.getElementById('adminBody').style.width = (myWidth-borderLeft-shadowLeft-shadowRight-borderRight-marginInnerLeft-marginInnerRight-InnerBorderLeft-InnerborderRight) + "%";
    document.getElementById('adminBody').style.height = (myHeight-borderTop-shadowTop-shadowBottom-borderBottom-marginInnerTop-marginInnerBottom-InnerBorderTop-InnerBorderBottom-headerHeight-20) + "px";
    
    innerContentHolderAreaHeight = (myHeight-borderTop-shadowTop-shadowBottom-borderBottom-marginInnerTop-marginInnerBottom-InnerBorderTop-InnerBorderBottom-headerHeight-innerContentHeaderHeight)
    //document.getElementById('innerContentHolderArea').style.height = innerContentHolderAreaHeight + "px";
    
    document.getElementById('adminBodyMenu').style.height = document.getElementById('adminBody').style.height;
    document.getElementById('adminBodyContent').style.height = document.getElementById('adminBody').style.height;
//  debugger;
//alert( document.getElementById('innerContentHolderArea').style.height );
    if ( document.getElementById('innerMenu').style.display == "none" )
        {
            document.getElementById('adminBodyMenu').style.width = (menuMinWidth) + "%";
            document.getElementById('adminBodyContent').style.width = (myWidth-borderLeft-shadowLeft-shadowRight-borderRight-marginInnerLeft-marginInnerRight-InnerBorderLeft-InnerborderRight-menuMinWidth) + "%";
        }
    else
        {
            document.getElementById('adminBodyMenu').style.width = (menuMaxWidth) + "%";
            document.getElementById('adminBodyContent').style.width = (myWidth-borderLeft-shadowLeft-shadowRight-borderRight-marginInnerLeft-marginInnerRight-InnerBorderLeft-InnerborderRight-menuMaxWidth) + "%";
        }
}