function check_Status() {
   
   
    Calender_details.Employee_read_Status(fill_result_value_inserted_new);
}

function fill_result_value_inserted_new()
{

}
var parseXml;
if (window.DOMParser) {
    parseXml = function (xmlStr) {
        return (new window.DOMParser()).parseFromString(xmlStr, "text/xml");
    };
}
else if (typeof window.ActiveXObject != "undefined" && new window.ActiveXObject("Microsoft.XMLDOM")) {
    parseXml = function (xmlStr) {
        var xmlDoc = new window.ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.loadXML(xmlStr);
        return xmlDoc;
    };
}
else {
    parseXml = function () { return null; }
}

function GetInnerText(node) {
    return (node.textContent || node.innerText || node.text);
}