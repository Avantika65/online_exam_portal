 //*****************************Dragger Code*********************************************
 var Drag = {
obj : null,
init : function(o, oRoot, minX, maxX, minY, maxY, bSwapHorzRef, bSwapVertRef, fXMapper, fYMapper)
{
o.onmousedown = Drag.start;
o.hmode = bSwapHorzRef ? false : true ;
o.vmode = bSwapVertRef ? false : true ;
o.root = oRoot && oRoot != null ? oRoot : o ;
if (o.hmode && isNaN(parseInt(o.root.style.left ))) o.root.style.left = "0px";
if (o.vmode && isNaN(parseInt(o.root.style.top ))) o.root.style.top = "0px";
if (!o.hmode && isNaN(parseInt(o.root.style.right ))) o.root.style.right = "0px";
if (!o.vmode && isNaN(parseInt(o.root.style.bottom))) o.root.style.bottom = "0px";
o.minX = typeof minX != 'undefined' ? minX : null;
o.minY = typeof minY != 'undefined' ? minY : null;
o.maxX = typeof maxX != 'undefined' ? maxX : null;
o.maxY = typeof maxY != 'undefined' ? maxY : null;
o.xMapper = fXMapper ? fXMapper : null;
o.yMapper = fYMapper ? fYMapper : null;
o.root.onDragStart = new Function();
o.root.onDragEnd = new Function();
o.root.onDrag = new Function();
},
start : function(e)
{
var o = Drag.obj = this;
e = Drag.fixE(e);
var y = parseInt(o.vmode ? o.root.style.top : o.root.style.bottom);
var x = parseInt(o.hmode ? o.root.style.left : o.root.style.right );
o.root.onDragStart(x, y);
o.lastMouseX = e.clientX;
o.lastMouseY = e.clientY;
if (o.hmode) {
if (o.minX != null) o.minMouseX = e.clientX - x + o.minX;
if (o.maxX != null) o.maxMouseX = o.minMouseX + o.maxX - o.minX;
} else {
if (o.minX != null) o.maxMouseX = -o.minX + e.clientX + x;
if (o.maxX != null) o.minMouseX = -o.maxX + e.clientX + x;
}
if (o.vmode) {
if (o.minY != null) o.minMouseY = e.clientY - y + o.minY;
if (o.maxY != null) o.maxMouseY = o.minMouseY + o.maxY - o.minY;
} else {
if (o.minY != null) o.maxMouseY = -o.minY + e.clientY + y;
if (o.maxY != null) o.minMouseY = -o.maxY + e.clientY + y;
}
document.onmousemove = Drag.drag;
document.onmouseup = Drag.end;
return false;
},
drag : function(e)
{
e = Drag.fixE(e);
var o = Drag.obj;
var ey = e.clientY;
var ex = e.clientX;
var y = parseInt(o.vmode ? o.root.style.top : o.root.style.bottom);
var x = parseInt(o.hmode ? o.root.style.left : o.root.style.right );
var nx, ny;
if (o.minX != null) ex = o.hmode ? Math.max(ex, o.minMouseX) : Math.min(ex, o.maxMouseX);
if (o.maxX != null) ex = o.hmode ? Math.min(ex, o.maxMouseX) : Math.max(ex, o.minMouseX);
if (o.minY != null) ey = o.vmode ? Math.max(ey, o.minMouseY) : Math.min(ey, o.maxMouseY);
if (o.maxY != null) ey = o.vmode ? Math.min(ey, o.maxMouseY) : Math.max(ey, o.minMouseY);
nx = x + ((ex - o.lastMouseX) * (o.hmode ? 1 : -1));
ny = y + ((ey - o.lastMouseY) * (o.vmode ? 1 : -1));
if (o.xMapper) nx = o.xMapper(y)
else if (o.yMapper) ny = o.yMapper(x)
Drag.obj.root.style[o.hmode ? "left" : "right"] = nx + "px";
Drag.obj.root.style[o.vmode ? "top" : "bottom"] = ny + "px";
Drag.obj.lastMouseX = ex;
Drag.obj.lastMouseY = ey;
Drag.obj.root.onDrag(nx, ny);
return false;
},
end : function()
{
document.onmousemove = null;
document.onmouseup = null;
Drag.obj.root.onDragEnd( parseInt(Drag.obj.root.style[Drag.obj.hmode ? "left" : "right"]), 
parseInt(Drag.obj.root.style[Drag.obj.vmode ? "top" : "bottom"]));
Drag.obj = null;
},
fixE : function(e)
{
if (typeof e == 'undefined') e = window.event;
if (typeof e.layerX == 'undefined') e.layerX = e.offsetX;
if (typeof e.layerY == 'undefined') e.layerY = e.offsetY;
return e;
}
};
 //*************************************************************************************
 var cX = 0; var cY = 0; var rX = 0; var rY = 0;var hideTarget;
        function UpdateCursorPosition(e){ cX = e.pageX; cY = e.pageY;}
        function UpdateCursorPositionDocAll(e)
            { 
                cX = event.clientX; 
                cY = event.clientY;
            }
            if(document.all) 
                {
                   document.onmousemove = UpdateCursorPositionDocAll; 
                 }
            else 
                {
                 document.onmousemove = UpdateCursorPosition; 
                 }
        function AssignPosition(d) 
            {
                if(self.pageYOffset) 
                    {
	                rX = self.pageXOffset;
	                rY = self.pageYOffset;
	                }
                else if(document.documentElement && document.documentElement.scrollTop) 
                    {
	                    rX = document.documentElement.scrollLeft;
	                    rY = document.documentElement.scrollTop;
	                }
                else if(document.body) 
                    {
	                    rX = document.body.scrollLeft;
	                    rY = document.body.scrollTop;
	                }
                if(document.all) 
                    {
	                    cX += rX; 
	                    cY += rY;
	                }
                d.style.left = (cX+10) + "px";
                d.style.top = (cY+10) + "px";
            }
        function HideContent() 
            {
                if(hideTarget.id.length < 1) 
                    { return; }
                document.getElementById(hideTarget.id).style.display = "none";
            }
        function HideContent1(ctrl) 
            {
                ctrl.style.display = "none";
            }
         function ShowSplashWindow(d,targetpage) 
            {
                 var RedirURL="";
                var loc = window.location.href;   
                    loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "images/close.png" : loc;
                var arrUri=loc.split('/'); 
                    RedirURL=arrUri[0]+'//'+arrUri[2]+'/'+arrUri[3]+'/images/close.png';
                
                if(d.length < 1) { return; }
                var dd = document.getElementById(d);
                hideTarget=dd;
                //------------------------------------
                dd.innerHTML="<img style='margin-top:-3%;margin-left:-3%;position:absolute;' alt='close' src='"+RedirURL+"' onclick='javascript:HideContent();'/></br><iframe id='igadg' src='"+targetpage+"' Style='border:0px 0px 0px 0px'  width='500px' height='300px'></iframe>";
                //-----------------------------------
                
                        AssignPosition(dd);
                dd.style.display = "block";
            }
            function ShowCenteredWindow(d,targetpage) 
            {
                 var RedirURL="";
                var loc = window.location.href;   
                    loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "images/close.png" : loc;
                var arrUri=loc.split('/'); 
                    RedirURL=arrUri[0]+'//'+arrUri[2]+'/'+arrUri[3]+'/images/close.png';
                
                if(d.length < 1) { return; }
                var dd = document.getElementById(d);
                hideTarget=dd;
                //------------------------------------
                dd.innerHTML="<img style='margin-top:-3%;margin-left:-3%;position:absolute;' alt='close' src='"+RedirURL+"' onclick='javascript:HideContent();'/></br><iframe id='igadg' src='"+targetpage+"' Style='border:0px 0px 0px 0px'  width='600px' height='300px'></iframe>";
                //-----------------------------------
                
                //AssignPosition(dd);
                dd.style.display = "block";
                dd.style.left = "100px";
                dd.style.top = "100px";
            }
            
        function ShowContent(d,targetpage) 
            {
                if(d.length < 1) { return; }
                var dd = document.getElementById(d);
                hideTarget=dd;
                //------------------------------------
                dd.innerHTML="<a href='javascript:HideContent();' tooltip='Close' style='text-decoration:none;font-weight:bold;width:100%;' align='right'>X</a></br><iframe id='igadg' src='"+targetpage+"'  width='300px' height='500px'></iframe>";
                //-----------------------------------
                        AssignPosition(dd);
                dd.style.display = "block";
            }
        function ReverseContentDisplay(d) 
            {
                if(d.length < 1) { return; }
                var dd = document.getElementById(d);
                AssignPosition(dd);
                    if(dd.style.display == "none") 
                        { dd.style.display = "block"; }
                    else { dd.style.display = "none"; }
            }
        function ShowWindow(d) 
        {
            if(d.length < 1) { return; }
            var dd = document.getElementById(d);
            hideTarget=dd;
            //------------------------------------
            //dd.innerHTML="<a href='javascript:HideContent();' tooltip='Close' style='text-decoration:none;font-weight:bold;width:100%;' align='right'>X</a></br><iframe id='igadg' src='"+targetpage+"'  width='300px' height='500px'></iframe>";
            //-----------------------------------
//                    AssignPosition(dd);
            dd.style.display = "block";
        }
        function ShowTooltip(tip) 
        {
            if(tip.length < 1) { return; }
            var dd = document.getElementById(tip);
            //hideTarget=dd;           
                    AssignPosition(dd);
            dd.style.display = "block";
        } 
        function HideTooltip(tip) 
            {
                document.getElementById(tip).style.display = "none";
            }
            
         function ShowDivWindow(d) 
        {
            if(d.length < 1) { return; }
            var dd = document.getElementById(d);
            hideTarget=dd;
            //------------------------------------
            //dd.innerHTML="<a href='javascript:HideContent();' tooltip='Close' style='text-decoration:none;font-weight:bold;width:100%;' align='right'>X</a></br><iframe id='igadg' src='"+targetpage+"'  width='300px' height='500px'></iframe>";
            //-----------------------------------
                    AssignPosition(dd);
            dd.style.display = "block";
            dd.style.left = "100px";
            dd.style.top = "100px";
        }